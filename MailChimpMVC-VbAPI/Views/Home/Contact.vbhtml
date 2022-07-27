@*@Code
        ViewData("Title") = "Contact"
    End Code

    <h2>@ViewData("Title").</h2>
    <h3>@ViewData("Message")</h3>*@

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
                    <form id="retrnfrm" method="post">
                        <h2> SUBSCRIBE To OUR NEWSLETTER</h2>


                        @Using Html.BeginForm("AddSubscribeUserAsync", "HomeController", FormMethod.Post, New With {.class = "form-style-1", .id = "retrnfrm"})


                            @<div Class="input-group">
                                <input type="email" Class="form-control" placeholder="Enter your email" id="subscribe" name="subscribe">
                                <Span Class="input-group-btn">
                                    <Button Class="btn" type="submit" value="Subscribe">Subscribe Now</Button>
                                </Span>
                            </div>

                            @If Not Model Is Nothing Then
                                @<span>Model.message</span>
                            End If

                        End Using

                    </form>
                </div>
            </div>
        </div>
    </div>
</section>
