using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data;

public class AsutusTestData
{
    public static void Seed(AsutusContext context)
    {
        if(context.Classifiers.Any())
            return;
        
        //Klassifikaatorit
        var dev = new Classifier{ Group = "Instance" , Code = "DEV",Name = "Arendus"};
        var test = new Classifier{ Group = "Instance" , Code = "TEST",Name = "Test"};
        var prelive = new Classifier{ Group = "Instance" , Code = "PRELIVE",Name = "Demo"};
        var live = new Classifier{ Group = "Instance" , Code = "LIVE",Name = "Toodang"};
        
        var est = new Classifier{ Group = "Language" , Code = "EST",Name = "Eesti keel"};
        var eng = new Classifier{ Group = "Language" , Code = "ENG",Name = "Inglise keel"};
        var rus = new Classifier{ Group = "Language" , Code = "RUS",Name = "Vene keel"};
        
        context.Classifiers.AddRange(dev, test, prelive, live, est, eng, rus);
        
        //Infosüsteemid
        var rr = new InformationSystem { Code = "RR", Name = "Rahvastikuregister" };
        var rrkp = new InformationSystem{ Code = "RRKP", Name = "Rahvastikuregistri iseteenindusportaal" };
        var rrmt = new InformationSystem{ Code = "RRMT", Name = "Rahvastikuregistri Meenetlustarkvara" };
        var ts = new InformationSystem{ Code = "TS", Name = "Teavitussüsteem" };
        var st = new InformationSystem{ Code = "ST", Name = "Sündmusteenuste rakendus" };

        context.InformationSystems.AddRange(rr, rrkp,rrmt, ts, st);
        context.SystemInstances.AddRange(
            new SystemInstance { InformationSystem = rr, InstanceType = dev },
            new SystemInstance { InformationSystem = rr, InstanceType = test },
            new SystemInstance { InformationSystem = rr, InstanceType = prelive },
            new SystemInstance { InformationSystem = rr, InstanceType = live },
            new SystemInstance { InformationSystem = rrkp, InstanceType = dev },
            new SystemInstance { InformationSystem = rrkp, InstanceType = test },
            new SystemInstance { InformationSystem = rrkp, InstanceType = prelive },
            new SystemInstance { InformationSystem = rrkp, InstanceType = live },
            new SystemInstance { InformationSystem = rrmt, InstanceType = dev },
            new SystemInstance { InformationSystem = rrmt, InstanceType = test },
            new SystemInstance { InformationSystem = rrmt, InstanceType = prelive },
            new SystemInstance { InformationSystem = rrmt, InstanceType = live },
            new SystemInstance { InformationSystem = ts, InstanceType = dev },
            new SystemInstance { InformationSystem = ts, InstanceType = test },
            new SystemInstance { InformationSystem = ts, InstanceType = prelive },
            new SystemInstance { InformationSystem = st, InstanceType = dev }
        );

        //Asutused
        context.Asutused.AddRange(
            new Asutus {
                Code = "TPS",
                Name = "Tallinna Perekonnaseisuamet",
                StartDate = new DateTime(2011, 11, 11),
                Translations = new List<Translation>()
                {
                    new Translation { Language = est, Text = "Tallinna Perekonnaseisuamet" },
                    new Translation { Language = eng, Text = "Tallinn Vital Statistics Department" },
                    new Translation { Language = rus, Text = "Таллиннский департамент записи актов гражданского состояния" },
                }
            },
            new Asutus {
                Code = "TLV",
                Name = "Tallinna Linnavalitsus",
                StartDate = new DateTime(2012, 12, 12),
                Translations = new List<Translation>()
                {
                    new Translation { Language = est, Text = "Tallinna Linnavalitsus" },
                    new Translation { Language = eng, Text = "Tallinn City Government" }
                }
            }
        );

        context.SaveChanges();
    }
}