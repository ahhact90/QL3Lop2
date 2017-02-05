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

using System;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace CuscLibrary.Win.WinForm.DevEx.Utilities
{
    public class XtraGridUtils
    {
        /* -------------------------------- Enums ------------------------------------ */
        #region "Enums"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------- Variables --------------------------------- */
        #region "Variables"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Properties --------------------------------- */
        #region "Properties"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* -------------------------------- Methods ---------------------------------- */
        #region "Methods"
        public static GridColumn CreateColumn(string fieldName, string caption, bool isVisible,
            int visibleIndex)
        {
            return new GridColumn
            {
                FieldName = fieldName,
                Caption = caption,
                Name = Guid.NewGuid().ToString(),
                Visible = isVisible,
                VisibleIndex = visibleIndex,
            };
        }

        #region "Calculate level GridBand"
        public static int GetMaxLevel(GridBandCollection bandCollection)
        {
            int max = 0;
            foreach (GridBand band in bandCollection)
            {
                int temp = GetLevel(band);
                if (max < temp)
                    max = temp;
            }
            return max;
        }

        public static int GetLevel(GridBand band)
        {
            if (!band.Visible)
                return 0;

            if (!band.HasChildren)
                return band.BandLevel;

            int max = band.BandLevel;
            foreach (GridBand b in band.Children)
            {
                int temp = GetLevel(b);
                if (max < temp)
                    max = temp;
            }
            return max;
        }
        #endregion

        #region "Calculate width GridBand"
        // Tính chiều rộng grid
        public static int GetWidth(GridBand band)
        {
            if (!band.Visible)
                return 0;

            if (!band.HasChildren)
                return 1;

            int max = 0;
            foreach (GridBand b in band.Children)
            {
                int temp = GetWidth(b);
                max += temp;
            }
            return max;
        }
        #endregion

      

        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------- Event handlers--------------------------------- */
        #region "Event handlers"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Sub classes -------------------------------- */
        #region "Sub classes"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------------- Test ------------------------------------ */
        #region "Tests"

        // Method test code
        private void Test()
        {
            // Todo: test code here
        }

        #endregion
        /* --------------------------------------------------------------------------- */
        
    }
}