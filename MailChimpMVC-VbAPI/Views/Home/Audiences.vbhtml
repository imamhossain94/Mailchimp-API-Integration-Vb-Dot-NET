@Imports MailChimp.Net.Models
@ModelType IEnumerable(Of List)


@Code
    ViewData("Title") = "Audiences"
End Code


<!-- Hero -->
<div class="mt-3 mb-2 text-center bg-image rounded-3" style="
    background-image: url('https://mdbcdn.b-cdn.net/img/new/slides/041.webp');
    height: 400px;">
    <div class="mask h-100 rounded-3" style="background-color: rgba(0, 0, 0, 0.6);">
        <div class="d-flex justify-content-center align-items-center h-100">
            <div class="text-white p-5">
                <h1 class="mb-3">@ViewData("Title")</h1>
                <h4 class="mb-3">
                    Your Mailchimp audience is designed to help you collect and manage subscribed, non-subscribed, and unsubscribed contacts
                </h4>
            </div>
        </div>
    </div>
</div>
<!-- Hero -->




<table class="table table-dark table-striped">
    <thead>
        <tr>
            <th scope="col">#</th>
            <th scope="col">Id</th>
            <th scope="col">Name</th>
            <th scope="col">Rating</th>
        </tr>
    </thead>
    <tbody>

        @If Not Model Is Nothing Then
            Dim id As Int16 = 1
            For Each value In Model
                @<tr>
                    <th scope="row"> @id</th>
                    <td>@value.Id</td>
                    <td>@value.Name</td>
                    <td>@value.ListRating</td>
                </tr>
                id += 1
            Next

        End If
    </tbody>
</table>
