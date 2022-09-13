using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DateSheetChoose.Common
{
    /// <summary>
    /// 用于动态读取、生成自定义模块
    /// </summary>
    public class DynamicModules
    {
        /// <summary>
        /// 创建新的模块文件
        /// </summary>
        /// <param name="path">保存文件路径，默认为运行exe文件夹下</param>
        /// <param name="sb">需要保存的文本</param>
        public void CreateModules(string path,StringBuilder sb)
        {
            using (StreamWriter sw=new StreamWriter(path))
            {
                //将文本填入
                sw.Write(sb.ToString());
                //释放文本
                sw.Close();
            }
        }


    }
}
