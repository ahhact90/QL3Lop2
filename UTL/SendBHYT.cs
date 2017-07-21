using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTL
{
    class SendBHYT
    {
        public static bool Send_BHYT(string PathBHYT)
        {
            switch (0)
            {
                case 0:
                    {
                    IL_0E:
                        bool result3;
                        try
                        {
                            while (true)
                            {
                                string text = global::eval_b.eval_a().tentk;
                                string text2 = global::eval_b.eval_a().matkhau;
                                HttpClient httpClient = new HttpClient();
                                httpClient.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn");
                                httpClient.DefaultRequestHeaders.Accept.Clear();
                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                System.Collections.Generic.Dictionary<string, string> nameValueCollection = new System.Collections.Generic.Dictionary<string, string>
						{
							{
								"username",
								text
							},
							{
								"password",
								text2
							}
						};
                                FormUrlEncodedContent content = new FormUrlEncodedContent(nameValueCollection);
                                HttpResponseMessage result = httpClient.PostAsync("api/token/take", content).Result;
                                string result2 = result.Content.ReadAsStringAsync().Result;
                                string[] array = result2.Split(new char[]
						{
							','
						});
                                string[] array2 = array[0].Split(new char[]
						{
							':'
						});
                                string s = array2[1].Substring(1, checked(array2[1].Length - 2));
                                bool flag = int.Parse(s) == 401;
                                int num = 5;
                                while (true)
                                {
                                    System.IO.FileStream fileStream;
                                    byte[] value;
                                    string text3;
                                    string text4;
                                    switch (num)
                                    {
                                        case 0:
                                            goto IL_226;
                                        case 1:
                                            result3 = false;
                                            num = 4;
                                            continue;
                                        case 2:
                                            {
                                                try
                                                {
                                                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                                                    try
                                                    {
                                                        fileStream.CopyTo(memoryStream);
                                                        value = memoryStream.ToArray();
                                                    }
                                                    finally
                                                    {
                                                        while (true)
                                                        {
                                                            flag = (memoryStream != null);
                                                            num = 2;
                                                            while (true)
                                                            {
                                                                switch (num)
                                                                {
                                                                    case 0:
                                                                        ((System.IDisposable)memoryStream).Dispose();
                                                                        num = 1;
                                                                        continue;
                                                                    case 1:
                                                                        goto IL_2A6;
                                                                    case 2:
                                                                        if (flag)
                                                                        {
                                                                            num = 0;
                                                                            continue;
                                                                        }
                                                                        goto IL_2A8;
                                                                }
                                                                break;
                                                            }
                                                        }
                                                    IL_2A6:
                                                    IL_2A8: ;
                                                    }
                                                    goto IL_173;
                                                }
                                                finally
                                                {
                                                    while (true)
                                                    {
                                                        flag = (fileStream != null);
                                                        num = 1;
                                                        while (true)
                                                        {
                                                            switch (num)
                                                            {
                                                                case 0:
                                                                    ((System.IDisposable)fileStream).Dispose();
                                                                    num = 2;
                                                                    continue;
                                                                case 1:
                                                                    if (flag)
                                                                    {
                                                                        num = 0;
                                                                        continue;
                                                                    }
                                                                    goto IL_2FA;
                                                                case 2:
                                                                    goto IL_2F8;
                                                            }
                                                            break;
                                                        }
                                                    }
                                                IL_2F8:
                                                IL_2FA: ;
                                                }
                                                goto IL_2FC;
                                            IL_173:
                                                string str = string.Format("token={0}&id_token={1}&username={2}&password={3}&loaiHoSo={4}&maTinh={5}&maCSKCB={6}", new object[]
								{
									text3,
									text4,
									text,
									text2,
									"3",
									global::eval_b.eval_a().matinh,
									global::eval_b.eval_a().macskcb
								});
                                                HttpResponseMessage result4 = httpClient.PostAsJsonAsync(System.Convert.ToString("api/egw/guiHoSoGiamDinh?") + str, value).Result;
                                                NClient.WriteLog(PathBHYT + "|" + result4.Content.ReadAsStringAsync().Result, "send", "send");
                                                result3 = true;
                                                num = 0;
                                                continue;
                                            }
                                        case 3:
                                            goto IL_38C;
                                        case 4:
                                            goto IL_239;
                                        case 5:
                                            if (flag)
                                            {
                                                num = 1;
                                                continue;
                                            }
                                            goto IL_2FC;
                                    }
                                    break;
                                IL_2FC:
                                    string[] array3 = array[1].Split(new char[]
							{
								':'
							});
                                    text3 = array3[2].Replace("\"", "");
                                    string[] array4 = array[2].Split(new char[]
							{
								':'
							});
                                    text4 = array4[1].Replace("\"", "");
                                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(PathBHYT);
                                    value = null;
                                    fileStream = fileInfo.OpenRead();
                                    num = 2;
                                }
                            }
                        IL_226:
                        IL_239:
                            goto IL_3A4;
                        IL_38C:
                            goto IL_12;
                        }
                        catch (System.Exception expr_391)
                        {
                            ProjectData.SetProjectError(expr_391);
                            ProjectData.ClearProjectError();
                            goto IL_12;
                        }
                        goto IL_3A4;
                    IL_12:
                        result3 = false;
                    IL_3A4:
                        if (true)
                        {
                        }
                        return result3;
                    }
            }
            goto IL_0E;
        }
    }
}
