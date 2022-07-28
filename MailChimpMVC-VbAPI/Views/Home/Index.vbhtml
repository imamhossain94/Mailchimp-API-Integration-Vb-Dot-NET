@Code
    ViewData("Title") = "Home Page"
End Code


<!-- Hero -->
<div class="mt-3 text-center bg-image rounded-3" style="
    background-image: url('https://mdbcdn.b-cdn.net/img/new/slides/041.webp');
    height: 400px;">
    <div class="mask h-100 rounded-3" style="background-color: rgba(0, 0, 0, 0.6);">
        <div class="d-flex justify-content-center align-items-center h-100">
            <div class="text-white p-5">
                <h1 class="mb-3">@ViewData("Title")</h1>
                <h4 class="mb-3">Vb.Net - integrate with MailChimp API</h4>
                <a class="btn btn-outline-light btn-lg" href="#!" role="button">Send Email</a>
            </div>
        </div>
    </div>
</div>
<!-- Hero -->
@Html.Partial("_NewsLetter")