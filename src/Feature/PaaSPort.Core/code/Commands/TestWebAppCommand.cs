using System;
using System.Collections.Specialized;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Version = Sitecore.Data.Version;

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
            var obj = context.Items[0];
            var parameters = new NameValueCollection();
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
            var obj = context.Items[0];
            var resourceName = obj.Fields["ResourceName"] != null ? obj.Fields["ResourceName"].Value : string.Empty;
            if (Context.IsAdministrator)
                return string.IsNullOrEmpty(resourceName) ? CommandState.Hidden : CommandState.Enabled;

            //if (obj.Appearance.ReadOnly || !obj.Access.CanWrite() || (!obj.Locking.HasLock() || !obj.Access.CanWriteLanguage()))
            //    return CommandState.Disabled;
            return base.QueryState(context);
        }


        /// <summary>Runs the specified args.</summary>
        /// <param name="args">The arguments.</param>
        protected void Run(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (!SheerResponse.CheckModified())
                return;
            var itemNotNull = Client.GetItemNotNull(args.Parameters["id"], Language.Parse(args.Parameters["language"]),
                Version.Parse(args.Parameters["version"]));
            if (!itemNotNull.Locking.HasLock() && !Context.IsAdministrator)
                return;
            Log.Audit(this, "Check in: {0}", AuditFormatter.FormatItem(itemNotNull));
            itemNotNull.Editing.BeginEdit();
            itemNotNull.Locking.Unlock();
            itemNotNull.Editing.EndEdit();
            Context.ClientPage.SendMessage(this, "item:checkedin");
        }
    }
}