using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tavis.JsonPatch
{
    public class RemoveOperation : Operation
    {
        
        public override void Write(JsonWriter writer)
        {
            writer.WriteStartObject();

            WriteOp(writer, "remove");
            WritePath(writer, Path);

            writer.WriteEndObject();
        }

        public override void Read(JObject jOperation)
        {
            Path = new JsonPointer((string)jOperation.GetValue("path"));   
        }
    }
}