Imports System.Threading.Tasks
Imports MailChimpMVC_VbAPI.Controllers


Public Class HomeController
    Inherits Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Async Function Audiences() As Task(Of ActionResult)

        Dim response = Await New MailchimpController().GetAudienceList()
        Return View(response)

    End Function

    Async Function Users(frc As FormCollection) As Task(Of ActionResult)

        Try
            Dim listId As String = frc.Get("audiencesId")
            Dim response = Await New MailchimpController().GetContactsList(listId)
            Return View(response)
        Catch ex As Exception
            Return View()
        End Try

    End Function

    Async Function Groups(frc As FormCollection) As Task(Of ActionResult)

        Try
            Dim listId As String = frc.Get("audiencesId")
            Dim response = Await New MailchimpController().GetGroupList(listId)
            Return View(response)
        Catch ex As Exception
            Return View()
        End Try

    End Function

    Async Function Categories(frc As FormCollection) As Task(Of ActionResult)

        Try
            Dim listId As String = frc.Get("audiencesId")
            Dim groupId As String = frc.Get("groupsId")
            Dim response = Await New MailchimpController().GetGroupCatrgoriesList(listId, groupId)
            Return View(response)
        Catch ex As Exception
            Return View()
        End Try

    End Function

    Async Function Update(frc As FormCollection) As Task(Of ActionResult)

        Try
            Await New MailchimpController().AddOrUpdateContact(frc)
            Response.Write("<script>alert('Contact Added or Updated successfuly!');</script>")
        Catch ex As Exception

        End Try

        Return View()

    End Function

    Async Function Email(frc As FormCollection) As Task(Of ActionResult)

        Try
            Dim result As Boolean = Await New MailchimpController().SendEmail(frc)
            If result = True Then
                Response.Write("<script>alert('Email submitted successfuly!');</script>")
            End If
        Catch ex As Exception

        End Try

        Return View()

    End Function

End Class
