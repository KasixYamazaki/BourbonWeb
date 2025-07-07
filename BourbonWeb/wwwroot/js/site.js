// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    const sidebar = document.getElementById('sidebar');
    if (sidebar) {
        sidebar.addEventListener('click', function (e) {
            if (e.target.tagName === 'A') {
                const offcanvas = bootstrap.Offcanvas.getInstance(sidebar);
                if (offcanvas) {
                    offcanvas.hide();
                }
            }
        });
    }
});
