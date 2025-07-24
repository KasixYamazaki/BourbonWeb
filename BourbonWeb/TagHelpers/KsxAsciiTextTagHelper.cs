using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BourbonWeb.TagHelpers
{
    [HtmlTargetElement("ksx-ascii-text")]
    public class KsxAsciiTextTagHelper(IHtmlGenerator htmlGenerator) : TagHelper
    {
        private readonly IHtmlGenerator _htmlGenerator = htmlGenerator;

        // asp-for でバインドするモデルプロパティ
        [HtmlAttributeName("asp-for")]
        public ModelExpression? For { get; set; }

        // 任意指定可能な追加属性
        [HtmlAttributeName("placeholder")]
        public string? Placeholder { get; set; }

        [HtmlAttributeName("maxlength")]
        public int? MaxLength { get; set; }

        [HtmlAttributeName("min")]
        public string? Min { get; set; }    // string → string? に変更

        [HtmlAttributeName("max")]
        public string? Max { get; set; }    // string → string? に変更

        [HtmlAttributeName("required")]
        public bool Required { get; set; }

        [HtmlAttributeName("readonly")]
        public bool ReadOnly { get; set; }

        [HtmlAttributeName("disabled")]
        public bool Disabled { get; set; }

        // ViewContextの取得（HTML生成に必要）
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext? ViewContext { get; set; } // ViewContext → ViewContext? に変更

        // TagHelperのメイン処理
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // 親コンテナ <div class="mb-3 form-group">
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "mb-3 form-group");

            // 1. <label> 要素生成 (asp-forに基づく表示名)
            var labelTag = (For != null && ViewContext != null)
                ? _htmlGenerator.GenerateLabel(
                    ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    labelText: null,
                    htmlAttributes: new { @class = "form-label" }
                )
                : null;

            // 2. <input type="text"> 要素生成 (名前・ID・検証属性付与)
            var inputTag = (For != null && ViewContext != null)
                ? _htmlGenerator.GenerateTextBox(
                    ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    value: null,
                    format: null,
                    htmlAttributes: new { @class = "form-control" }
                )
                : null;

            if (inputTag != null)
            {
                inputTag.Attributes["pattern"] = "[A-Za-z0-9]*";
                inputTag.Attributes["inputmode"] = "latin";
                inputTag.Attributes["oninput"] = "this.value=this.value.replace(/[^A-Za-z0-9]/g,'');";

                if (!string.IsNullOrEmpty(Placeholder))
                    inputTag.Attributes["placeholder"] = Placeholder;
                if (MaxLength.HasValue)
                    inputTag.Attributes["maxlength"] = MaxLength.Value.ToString();
                if (!string.IsNullOrEmpty(Min))
                    inputTag.Attributes["min"] = Min;
                if (!string.IsNullOrEmpty(Max))
                    inputTag.Attributes["max"] = Max;
                if (Required)
                    inputTag.Attributes["required"] = "required";
                if (ReadOnly)
                    inputTag.Attributes["readonly"] = "readonly";
                if (Disabled)
                    inputTag.Attributes["disabled"] = "disabled";
            }

            // サーバーサイドのモデル検証エラー確認
            bool hasError = false;
            if (For != null && ViewContext?.ViewData?.ModelState != null)
            {
                string modelName = For.Name;
                if (ViewContext.ViewData.ModelState.TryGetValue(modelName, out var entry) && entry.Errors.Count > 0)
                {
                    hasError = true;
                }
            }
            if (hasError && inputTag != null)
            {
                string existingClass = inputTag.Attributes.ContainsKey("class") && inputTag.Attributes["class"] != null
                    ? inputTag.Attributes["class"]!
                    : "";
                inputTag.Attributes["class"] = (existingClass + " is-invalid").Trim();
            }

            // 3. 検証メッセージ要素の生成 (<div class="invalid-feedback">)
            TagBuilder? validationTag = (For != null && ViewContext != null)
                ? _htmlGenerator.GenerateValidationMessage(
                    ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    message: null,
                    tag: "div",
                    htmlAttributes: new { @class = "invalid-feedback" }
                )
                : null;

            // 4. 生成した要素を出力に追加
            if (labelTag != null)
                output.Content.AppendHtml(labelTag);
            if (inputTag != null)
                output.Content.AppendHtml(inputTag);
            if (validationTag != null)
                output.Content.AppendHtml(validationTag);
        }
    }
}