using TD.Dynamic;
using TD.Serialize.Base;

namespace TD.Serialize
{
    public class Json : JSonBase
    {
        public override dynamic DeserializeObject(string content)
        {
            //dynamic data = new JsonDynamic(content);
            //return data;
            return base.DeserializeObject(content);
        }
    }
}
