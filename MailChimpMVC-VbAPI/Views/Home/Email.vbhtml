@Code
    ViewData("Title") = "Email"
End Code


<div class="m-5">

    @Using Html.BeginForm("SendEmail", "Mailchimp", FormMethod.Post)


        @<div class="mb-3">
            <label for="emailAddress" class="form-label">Reply to email</label>
            <input type="email" class="form-control" id="emailAddress" name="emailAddress" aria-describedby="emailHelp">
            <div id="emailHelp" class="form-text">Enter valid email address.</div>
        </div>

        @<div class="mb-3">
            <label for="categoriesId" class="form-label">Reply to group</label>
            <input type="text" class="form-control" id="categoriesId" name="categoriesId" aria-describedby="categoriesIdHelp">
            <div id="categoriesIdHelp" class="form-text">Enter categories id of a group</div>
        </div>


        @<div class="mb-3">
            <label for="replyFrom" class="form-label">Reply From</label>
            <input type="text" class="form-control" id="replyFrom" name="replyFrom" aria-describedby="replyFromHelp" required>
            <div id="replyFromHelp" class="form-text">Enter sender name.</div>
        </div>


        @<div class="mb-3">
            <label for="campaignTitle" class="form-label">Campaign title</label>
            <input type="text" class="form-control" id="campaignTitle" name="campaignTitle" aria-describedby="campaignTitleHelp" required>
            <div id="campaignTitleHelp" class="form-text">Enter campaign title</div>
        </div>


        @<div class="mb-3">
            <label for="emailSubject" class="form-label">Email subject</label>
            <input type="text" class="form-control" id="emailSubject" name="emailSubject" aria-describedby="emailSubjectHelp" required>
            <div id="emailSubjectHelp" class="form-text">Enter valid email address.</div>
        </div>


        @<div class="mb-3">
            <label for="emailBody" class="form-label">Email body</label>
            <textarea class="form-control" id="emailBody" rows="4" name="emailBody" aria-describedby="emailBodyHelp"></textarea>
            <div id="emailBodyHelp" class="form-text">Enter plain text.</div>
        </div>


        @<div class="mb-3">
            <label for="audieancesId" class="form-label">Audieance id</label>
            <input type="text" class="form-control" id="audieancesId" name="audieancesId" aria-describedby="audieancesIdHelp" required>
            <div id="audieancesIdHelp" class="form-text">Enter audieance id.</div>
        </div>


        @<button type="submit" class="btn btn-dark">Add or Update</button>
    End Using

</div>
