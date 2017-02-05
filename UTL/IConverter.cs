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


namespace CuscLibrary.DataTypes
{
    /// <summary>
    /// 	Generic converter interface used to allow extension methods to be applied.
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    public interface IConverter<T>
    {
        /// <summary>
        /// 	Gets the internal value to be converted.
        /// </summary>
        /// <value>The value.</value>
        T Value { get; }
    }
}
