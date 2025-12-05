// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
	document.querySelectorAll("ul li a").forEach(a => {
		a.addEventListener('click', (e) => {

			const id = e.currentTarget.getAttribute("id");
			alert("menu " + id+ " clicked");

			fetch('/Home/FillterByCategory?id=' + id)
				.then(Response => Response.text())
				 .then(html => {
					document.getElementById('list_product').innerHTML = html;
				 })
			    .catch(err => alert(err));
		});
	});
});