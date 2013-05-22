using ScriptCs.Contracts;

namespace ScriptCs.MemberPrint
{
    public class ScriptPack : IScriptPack
    {
        public void Initialize(IScriptPackSession session)
        {
            session.ImportNamespace("System.Reflection");
        }

        public IScriptPackContext GetContext()
        {
            return new MemberPrint();
        }

        public void Terminate()
        {
        }
    }
}