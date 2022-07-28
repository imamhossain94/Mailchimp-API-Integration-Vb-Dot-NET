Imports System.Threading.Tasks
Imports MailChimpMVC_VbAPI.Controllers


Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Async Function Audiences() As Task(Of ActionResult)

        Dim audienceList = Await New MailchimpController().GetAudienceList()

        Return View(audienceList)
    End Function

    Function Users() As ActionResult
        Return View()
    End Function

End Class
