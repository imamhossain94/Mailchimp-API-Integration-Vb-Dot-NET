@Imports MailChimpMVC_VbAPI.Models
@ModelType Response

@Code
    ViewData("Title") = "Home Page"
End Code


<section Class="newsletter">
    <div Class="container">
        <div Class="row">
            <div Class="col-sm-12">
                <div Class="content">
                    <div id="retrnfrm">
                        <h2> SUBSCRIBE To OUR NEWSLETTER</h2>
                        @Using Html.BeginForm("AddSubscribeUserAsync", "Mailchimp", FormMethod.Post)
                            @<div Class="form-group d-flex justify-content-center">
                                <input type="email" Class="form-control input-lg" placeholder="Enter your email" id="subscribe" name="subscribe">
                                <Span Class="input-group-btn">
                                    <Button Class="btn" type="submit" value="Subscribe">Subscrive Now</Button>
                                </Span>
                            </div>
                            @If Not Model Is Nothing Then
                                @<span>@Model.message</span>
                            End If
                        End Using
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>