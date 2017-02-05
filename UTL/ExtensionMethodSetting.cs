#region "Author"
/****************************************************************************************
 * Solution     : CUSC His Framework
 * Project code : APP1105
 * Author       : Dương Nguyễn Phú Cường
 * Company      : Cusc Software
 * Version      : 1.0.0.1
 * Created date : 29/03/2013
 ***************************************************************************************/
#endregion

using System.Globalization;
using System.Text;

namespace CuscLibrary.SystemDependencies
{
    /// <summary>
    /// Allows developer to set default values for CultureInfo and Encoding
    /// </summary>
    /// <remarks>Added by Jtolar</remarks>
    public static class ExtensionMethodSetting
    {
        /// <summary>
        /// Initializes a static instance of the ExtensionMethodsSettings class
        /// </summary>
        static ExtensionMethodSetting()
        {
            DefaultEncoding = Encoding.UTF8;
            DefaultCulture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Gets or Sets the default encoding scheme extension methods should use
        /// </summary>
        /// <remarks>
        /// The default value for this property is <see cref="Encoding.UTF8"/>
        /// </remarks>
        public static Encoding DefaultEncoding { get; set; }

        /// <summary>
        /// Gets or Sets the default culture information extension methods should use
        /// </summary>
        /// <remarks>
        /// The default value for this property is <see cref="CultureInfo.CurrentUICulture"/>
        /// </remarks>
        public static CultureInfo DefaultCulture { get; set; }
    }
}