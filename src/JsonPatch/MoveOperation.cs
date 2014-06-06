using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tavis.JsonPatch
{
    public class MoveOperation : Operation
    {
        public JsonPointer FromPath { get; set; }

        public override void Write(JsonWriter writer)
        {
            writer.WriteStartObject();

            WriteOp(writer, "move");
            WritePath(writer, Path);
            WriteFromPath(writer, FromPath);

            writer.WriteEndObject();
        }

        public override void Read(JObject jOperation)
        {
            Path = new JsonPointer((string)jOperation.GetValue("path"));
            FromPath = new JsonPointer((string)jOperation.GetValue("from"));
        }
    }
}