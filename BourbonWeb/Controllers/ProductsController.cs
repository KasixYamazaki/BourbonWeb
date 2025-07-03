// <copyright file="ProductsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BourbonWeb.Data;
using BourbonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BourbonWeb.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ProductsController(AppDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Displays a list of all products.
        /// </summary>
        /// <returns>A view containing the list of products.</returns>
        public async Task<IActionResult> Index()
        {
            return this.View(await this._context.Product.ToListAsync());
        }

        /// <summary>
        /// Displays details of a specific product.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>A view containing the product details.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var product = await this._context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.View(product);
        }

        /// <summary>
        /// Displays the product creation form.
        /// </summary>
        /// <returns>A view for creating a new product.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Handles the submission of the product creation form.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>A redirect to the product list view if successful; otherwise, the creation view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description")] Product product)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Add(product);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(product);
        }

        /// <summary>
        /// Displays the product editing form.
        /// </summary>
        /// <param name="id">The ID of the product to edit.</param>
        /// <returns>A view for editing the product.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var product = await this._context.Product.FindAsync(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.View(product);
        }

        /// <summary>
        /// Handles the submission of the product editing form.
        /// </summary>
        /// <param name="id">The ID of the product to edit.</param>
        /// <param name="product">The updated product details.</param>
        /// <returns>A redirect to the product list view if successful; otherwise, the editing view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description")] Product product)
        {
            if (id != product.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this._context.Update(product);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ProductExists(product.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(product);
        }

        /// <summary>
        /// Displays the product deletion confirmation view.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>A view for confirming the deletion of the product.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var product = await this._context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.View(product);
        }

        /// <summary>
        /// Handles the confirmation of product deletion.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>A redirect to the product list view.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this._context.Product.FindAsync(id);
            if (product != null)
            {
                this._context.Product.Remove(product);
            }

            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Checks if a product exists in the database.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>True if the product exists; otherwise, false.</returns>
        private bool ProductExists(int id)
        {
            return this._context.Product.Any(e => e.Id == id);
        }
    }
}