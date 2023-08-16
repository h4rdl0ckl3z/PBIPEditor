using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PBIPEditor.Properties
{
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [CompilerGenerated]
    [DebuggerNonUserCode]
    internal class Resources
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals((object)PBIPEditor.Properties.Resources.resourceMan, (object)null))
                    PBIPEditor.Properties.Resources.resourceMan = new ResourceManager("PBIPEditor.Properties.Resources", typeof(PBIPEditor.Properties.Resources).Assembly);
                return PBIPEditor.Properties.Resources.resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get => PBIPEditor.Properties.Resources.resourceCulture;
            set => PBIPEditor.Properties.Resources.resourceCulture = value;
        }
    }
}