using System.Text;
namespace LoadModules.Date
{
    public class FileModel
    {
        StringBuilder sb = new StringBuilder();
        public StringBuilder StandardModuleProgram
        {
            get
            {
                sb.Append("$请将文件名命名为模块名称[英文]，比如CMhp\n");
                sb.Append("$区块名定义为以下方式【冒号使用中文】\n");
                sb.Append("$区块名1+空格+中文翻译：参数1+空格+中文解释+空格|+空格参数2+空格+中文解释+空格|...|+空格参数N+空格+中文解释\n");
                sb.Append("$区块名2+空格+中文翻译：参数1+空格+中文解释+空格|+空格参数2+空格+中文解释+空格|...|+空格参数N+空格+中文解释\n");
                sb.Append("$比如：Type 类型 ：hp 高性能型 | ba 经济型\n");
                return sb;
            }
        }
    }
}
