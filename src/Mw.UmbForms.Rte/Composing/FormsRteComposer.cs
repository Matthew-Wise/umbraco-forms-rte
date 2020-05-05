using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Mw.UmbForms.Rte.Composing
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class FormsRteComposer : ComponentComposer<FormsRteComponent>
    {
    }
}
