using System;
using System.Globalization;
using System.Windows.Data;

namespace HMI.CO.Reports
{
    public enum RenderFormat
    {
        EXCEL, //Excel 2003     | *.xls
        EXCELOPENXML, //Excel   | *.xlsx
        IMAGE, //Tiff-Datei     | *.TIF
        PDF, //                 | *.pdf
        WORD, //Word 2003       | *.doc
        WORDOPENXML //Word      | *.docx
    }

    [ValueConversion(typeof(RenderFormat), typeof(string))]
    public class RenderModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileExtension = parameter is bool ? (bool)parameter : true;
            var renderMode = value is RenderFormat ? (RenderFormat)value : RenderFormat.PDF;

            if (fileExtension)
            {
                switch (renderMode)
                {
                    case RenderFormat.EXCEL:
                        return ".xls";
                    case RenderFormat.EXCELOPENXML:
                        return ".xlsx";
                    case RenderFormat.IMAGE:
                        return ".TIF";
                    case RenderFormat.PDF:
                        return ".pdf";
                    case RenderFormat.WORD:
                        return ".doc";
                    case RenderFormat.WORDOPENXML:
                        return ".docx";
                    default:
                        return ".pdf";
                }
            }
            switch (renderMode)
            {
                case RenderFormat.EXCEL:
                    return "EXCEL";
                case RenderFormat.EXCELOPENXML:
                    return "EXCELOPENXML";
                case RenderFormat.IMAGE:
                    return "IMAGE";
                case RenderFormat.PDF:
                    return "PDF";
                case RenderFormat.WORD:
                    return "WORD";
                case RenderFormat.WORDOPENXML:
                    return "WORDOPENXML";
                default:
                    return "PDF";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileExtension = parameter is bool ? (bool)parameter : true;
            var str = value as string;

            if (fileExtension)
            {
                switch (str)
                {
                    case ".xls":
                        return RenderFormat.EXCEL;
                    case ".xlsx":
                        return RenderFormat.EXCELOPENXML;
                    case ".TIF":
                        return RenderFormat.IMAGE;
                    case ".pdf":
                        return RenderFormat.PDF;
                    case ".doc":
                        return RenderFormat.WORD;
                    case ".docx":
                        return RenderFormat.WORDOPENXML;
                    default:
                        return RenderFormat.PDF;
                }
            }
            switch (str)
            {
                case "EXCEL":
                    return RenderFormat.EXCEL;
                case "EXCELOPENXML":
                    return RenderFormat.EXCELOPENXML;
                case "IMAGE":
                    return RenderFormat.IMAGE;
                case "PDF":
                    return RenderFormat.PDF;
                case "WORD":
                    return RenderFormat.WORD;
                case "WORDOPENXML":
                    return RenderFormat.WORDOPENXML;
                default:
                    return RenderFormat.PDF;
            }
        }
    }
}