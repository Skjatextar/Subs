using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using Subs.Models.Entity;

namespace Subs.App_Data.DataAccessLayer
{
    public class SubDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SubDataContext>
    {
        //protected override void Seed(SubDataContext context)
        //{
        //    var clients = new List<Client>
        //    {
        //        new Client
        //        {
        //            sUsername = "Guffi",
        //            sPass = "meistari",
        //            sEmail = "guffi@ru.is",
        //            iRanking = 1,
        //            iTheme = 1,
        //            dSignupDate = DateTime.Parse("07-05-2014")
        //        } //,
        //    };

        //    clients.ForEach(c => context.Clients.Add(c));
        //    context.SaveChanges();

        //    var comments = new List<Comment>
        //    {
        //        new Comment
        //        {
        //            iCommentId = 1,
        //            sCommentText = "Geðveikt",
        //            dCommentDate = DateTime.Parse("07-05-2014")
        //        }
        //    };

        //    comments.ForEach(c => context.Comments.Add(c));
        //    context.SaveChanges();
        //}
    }
}