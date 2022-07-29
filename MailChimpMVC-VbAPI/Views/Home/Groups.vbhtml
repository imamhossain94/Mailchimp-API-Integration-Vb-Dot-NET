@Imports MailChimp.Net.Models
@ModelType IEnumerable(Of InterestCategory)


@Code
    ViewData("Title") = "Groups"
End Code


<!-- Hero -->
<div class="mt-3 mb-2 text-center bg-image rounded-3" style="
    background-image: url('https://mdbcdn.b-cdn.net/img/new/slides/041.webp');
    height: 400px;">
    <div class="mask h-100 rounded-3" style="background-color: rgba(0, 0, 0, 0.6);">
        <div class="d-flex justify-content-center align-items-center h-100">
            <div class="text-white p-5">
                <h1 class="mb-3">Groups List</h1>

                @*<h4 class="mb-3">
                    Enter an audiences ID.
                </h4>*@

                @Using Html.BeginForm("Groups", "Home", FormMethod.Post)
                    @<div Class="form-group form bg-dark d-flex justify-content-center">
                        <input type="text" Class="form-control input-lg" placeholder="Enter an audiences id" name="audiencesId">
                        <Span Class="input-group-btn">
                            <Button Class="btn btn-dark" type="submit">Search</Button>
                        </Span>
                    </div>
                End Using

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
            <th scope="col">List Id</th>
            <th scope="col">Title</th>
            <th scope="col">Display Order</th>
            <th scope="col">Title</th>
        </tr>
    </thead>
    <tbody>

        @If Not Model Is Nothing Then
            Dim id As Int16 = 1
            For Each value In Model
                @<tr>
                    <th scope="row"> @id</th>
                    <td>@value.Id</td>
                    <td>@value.ListId</td>
                    <td>@value.Title</td>
                    <td>@value.DisplayOrder</td>
                    <td>@value.DisplayType</td>
                </tr>
                id += 1
            Next

        End If
    </tbody>
</table>
