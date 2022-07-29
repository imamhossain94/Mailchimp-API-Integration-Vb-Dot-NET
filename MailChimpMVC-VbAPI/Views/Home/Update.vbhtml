@Code
    ViewData("Title") = "Update"
End Code


<div class="m-5">

    @Using Html.BeginForm("Update", "Home", FormMethod.Post)
        @<div class="mb-3">
            <label for="firstName" class="form-label">First name</label>
            <input type="text" class="form-control" id="firstName" name="firstName" aria-describedby="firstNameHelp">
            <div id="firstNameHelp" class="form-text">Please enter first name</div>
        </div>

        @<div class="mb-3">
            <label for="lastName" class="form-label">Last name</label>
            <input type="text" class="form-control" id="lastName" name="lastName" aria-describedby="lastNameHelp">
            <div id="lastNameHelp" class="form-text">Please enter last name</div>
        </div>

        @<div class="mb-3">
            <label for="emailAddress" class="form-label">Email address</label>
            <input type="email" class="form-control" id="emailAddress" name="emailAddress" aria-describedby="emailHelp">
            <div id="emailHelp" class="form-text">Enter valid email address.</div>
        </div>

        @<div class="mb-3">
            <label for="audieancesId" class="form-label">Audieance id</label>
            <input type="text" class="form-control" id="audieancesId" name="audieancesId" aria-describedby="audieancesIdHelp">
            <div id="audieancesIdHelp" class="form-text">Enter audieance id.</div>
        </div>

        @<div class="mb-3">
            <label for="categoriesId" class="form-label">Categories id</label>
            <input type="text" class="form-control" id="categoriesId" name="categoriesId" aria-describedby="categoriesIdHelp">
            <div id="categoriesIdHelp" class="form-text">Enter categories id of a group</div>
        </div>

        @<button type="submit" class="btn btn-dark">Add or Update</button>
    End Using

</div>
