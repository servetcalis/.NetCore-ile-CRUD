// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    setTimeout(function () {

        $('div.notification').fadeOut();
    }, 3000);

    $('.deleteConfirm').click(function () {
        if (!confirm('Confirm Deletion')) {
            return false;
        }
    });
});