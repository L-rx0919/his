using Volo.Abp.Settings;

namespace HIS.Settings;

public class HISSettingDefinitionProvider : SettingDefinitionProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HISSettings.MySetting1));
    }
}
