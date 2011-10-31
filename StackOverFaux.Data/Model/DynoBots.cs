using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverFaux.Data.Model
{
    //At this point, Massive/This section isn't used.
    public class dynPosts : DynamicModel
    {
        //you don't have to specify the connection - Massive will use the first one it finds in your config
        public dynPosts()
            : base("SoFConnStr")
        {
            PrimaryKeyField = "PostId";
            TableName = "dbo.Posts";
        }

    }
}
