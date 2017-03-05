using System;
using System.Collections.Specialized;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace TheInjectables.Feature.PaaSPort.Core.Commands
{
    [Serializable]
    public class TestWebAppCommand : Command
    {
        /// <summary>Executes the command in the specified context.</summary>
        /// <param name="context">The context.</param>
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            if (context.Items.Length != 1)
                return;
            Item obj = context.Items[0];
            NameValueCollection parameters = new NameValueCollection();
            parameters["id"] = obj.ID.ToString();
            parameters["language"] = obj.Language.ToString();
            parameters["version"] = obj.Version.ToString();
            Context.ClientPage.Start(this, "Run", parameters);
        }


        /// <summary>Queries the state of the command.</summary>
        /// <param name="context">The context.</param>
        /// <returns>The state of the command.</returns>
        public override CommandState QueryState(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            if (context.Items.Length != 1)
                return CommandState.Hidden;
            Item obj = context.Items[0];
            var resourceName = obj.Fields["ResourceName"] != null ? obj.Fields["ResourceName"].Value : string.Empty;
            if (Context.IsAdministrator)
            {
                // Get the resource from DXF by resource name.
                return string.IsNullOrEmpty(resourceName) ? CommandState.Hidden : CommandState.Enabled;
            }

            //if (obj.Appearance.ReadOnly || !obj.Access.CanWrite() || (!obj.Locking.HasLock() || !obj.Access.CanWriteLanguage()))
            //    return CommandState.Disabled;
            return base.QueryState(context);
        }


        /// <summary>Runs the specified args.</summary>
        /// <param name="args">The arguments.</param>
        protected void Run(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");
            if (!SheerResponse.CheckModified())
                return;
            Item itemNotNull = Client.GetItemNotNull(args.Parameters["id"], Language.Parse(args.Parameters["language"]), Sitecore.Data.Version.Parse(args.Parameters["version"]));
            if (!itemNotNull.Locking.HasLock() && !Context.IsAdministrator)
                return;
            Log.Audit((object)this, "Check in: {0}", new string[1]
            {
                AuditFormatter.FormatItem(itemNotNull)
            });
            itemNotNull.Editing.BeginEdit();
            itemNotNull.Locking.Unlock();
            itemNotNull.Editing.EndEdit();
            Context.ClientPage.SendMessage((object)this, "item:checkedin");
        }
    }
}




