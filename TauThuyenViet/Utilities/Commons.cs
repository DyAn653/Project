using System;
using System.Text.RegularExpressions;

namespace TauThuyenViet.Utilities
{
    public static class Commons
    {
        public static string GetFirstImage(this string value)
        {
            string result = value.Split('\n')[0];
            return result;
        }

        public static string[] GetListImage(this string value)
        {
            string[] result = value.Split('\n');
            return result;
        }

        public static string RemoveSign(this string value)
        {
            string result = value;

            string[] charList = new string[] { "aáàảãạăắằẳẵặâấầẩẫậ", "oóòỏõọôốồổỗộơớờởỡợ", "eéèẻẽẹêếềểễệ", "iíìỉĩị", "uúùủũụưứừửữự", "yýỳỷỹỵ", "dđ", "-/\\,.?!" };

            //Chạy N lần, mỗi lần qua 1 đoạn trong charList
            for (int i = 0; i < charList.Length; i++)
            {
                //Chạy qua từng ký tự của 1 đoạn trong vòng for lớn
                for (int j = 1; j < charList[i].Length; j++)
                {
                    result = result.Replace(charList[i][j], charList[i][0]);
                    result = result.Replace(charList[i][j].ToString().ToUpper(), charList[i][j].ToString().ToUpper());
                }

            }
            #region Hàm charList TRUYỀN THỐNG

            //char[] a = new char[] { 'á', 'à', 'ả', 'ã', 'ạ',
            //                        'ă', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ',
            //                        'â', 'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ'};

            //for (int i = 0; i < a.Length; i++)
            //{
            //    result = result.Replace(a[i], 'a');
            //}

            ////Xử lý chữ o
            //char[] o = new char[] { 'o', 'ò', 'ỏ', 'õ', 'ọ',
            //                        'ô', 'ố', 'ồ', 'ổ', 'ỗ', 'ộ',
            //                        'ơ', 'ớ', 'ờ', 'ở', 'ỡ', 'ợ'};

            //for (int i = 0; i < o.Length; i++)
            //{
            //    result = result.Replace(o[i], 'o');
            //}

            ////Xử lý chữ e
            //char[] e = new char[] { 'e', 'è', 'ẻ', 'ẽ', 'ẹ',
            //                        'ê', 'ế', 'ề', 'ể', 'ễ', 'ệ'};

            //for (int i = 0; i < e.Length; i++)
            //{
            //    result = result.Replace(e[i], 'e');
            //}

            ////Xử lý chữ i
            //char[] iArray = new char[] { 'i', 'í', 'ì', 'ỉ', 'ĩ', 'ị' };

            //for (int i = 0; i < iArray.Length; i++)
            //{
            //    result = result.Replace(iArray[i], 'i');
            //}

            ////Xử lý chữ u
            //char[] u = new char[] { 'u', 'ú', 'ù', 'ủ', 'ũ', 'ụ' };

            //for (int i = 0; i < u.Length; i++)
            //{
            //    result = result.Replace(u[i], 'u');
            //}

            ////Xử lý chữ y
            //char[] yArray = new char[] { 'y', 'ý', 'ỳ', 'ỷ', 'ỹ', 'ỵ' };

            //for (int i = 0; i < yArray.Length; i++)
            //{
            //    result = result.Replace(yArray[i], 'y');
            //}

            ////Xử lý chữ d
            //char[] dArray = new char[] { 'đ' };

            //for (int i = 0; i < dArray.Length; i++)
            //{
            //    result = result.Replace(dArray[i], 'd');
            //} 
            ////Xử lý những ký tự đặc biệt
            //char[] symbolArray = new char[] { ' ', '/', '\\', ',', '.', '?', '!' };

            //for (int i = 0; i < symbolArray.Length; i++)
            //{
            //    result = result.Replace(symbolArray[i].ToString(), "");
            //}
            ////Xử lý những ký tự đặc biệt
            //result = result.Replace(" ", "-");
            #endregion

            return result;
        }

        public static string ToUrlFormat(this string value)
        {
            //-Không đấu                    ->Bỏ dấu
            //- Không cách                  ->Bỏ cách
            //- không viết hoa              -> Chuyển về chữ thường
            //-Không chứ ký tự đặc biệt     ->Bỏ ký tự đặc biệt


            ////Chưa tối ưu
            //value = value.Replace(" ", "-");
            //value = value.Replace("%", "-");
            //value = value.Replace("@", "-");
            //value = value.Replace("$", "-");
            //value = value.Replace("#", "-");

            value = value.ToLower();
            value = value.RemoveSign();

            //Tối ưu
            string charList = " ~!@#$%^&*()_+=-[]{}|\\;:',.?/><";
            for (int i = 0; i < charList.Length; i++)
            {
                value = value.Replace(charList[i], '-');
            }

            //Thay thế những dấu - kép thành dấu - đơn
            Regex regex = new Regex("-+");
            value = regex.Replace(value, "-");

            return value;
        }
    }
}
