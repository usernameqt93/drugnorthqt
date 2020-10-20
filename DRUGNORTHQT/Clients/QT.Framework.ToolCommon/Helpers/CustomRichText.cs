using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace QT.Framework.ToolCommon.Helpers
{
    public class CustomRichText : RichTextBox
    {

        public string RtfContent
        {
            get { return (string)GetValue(RtfContentProperty); }
            set { SetValue(RtfContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RtfContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RtfContentProperty =
            DependencyProperty.Register("RtfContent", typeof(string), typeof(CustomRichText), new PropertyMetadata(string.Empty, RftCallBack));

        /// <summary>
        /// Hàm gọi lại
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void RftCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichTextBox _richText = d as CustomRichText;
            using (MemoryStream stream = new MemoryStream(UnicodeEncoding.Default.GetBytes(e.NewValue.ToString())))
            {
                _richText.SelectAll();
                _richText.Selection.Load(stream, DataFormats.Rtf);
            }
        }
    }
}
