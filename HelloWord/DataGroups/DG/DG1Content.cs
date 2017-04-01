﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.BER_TLV;

namespace HelloWord.DataGroups.DG
{
    public class DG1Content 
    {
        private readonly IBinary _dg1Data;

        public DG1Content(IBinary dg1Data)
        {
            _dg1Data = dg1Data;
        }

        public override string ToString()
        {
            var str = new Hex(_dg1Data).ToString();
           // ICollection<Tlv> tlvs = Tlv.ParseTlv(str);
            var berTlv = new BerTLV(_dg1Data);
            //var berTlv = new BerTLV(new BinaryHex("75821FDA7F61821FD50201017F60821FCDA10C8002010087020101880200085F2E821FBA464143003031300000001FBA000100001FAC00000000000000000000000000000000010001900202000000000000FFD8FFE000104A46494600010200000100010000FFDB0043002116181C1814211C1A1C25232127315135312D2D3164474B3B5176687C7A746872708293BB9F828AB18C7072A3DEA5B1C1C7D2D4D27E9DE6F6E4CCF4BBCED2CAFFDB004301232525312B3160353560CA867286CACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACACAFFC00011080202019003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00DFA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A4240EA680168A84DCC40E3764FB535AE907AFE3401628AA0F7A09F94F4EB511BACF2724FE74AE3B1A2D2A2FDE703F1A61B88C1C6EFD2A98978DCC79F4E4546D36E3C0207A8268B8EC5E6BB8D7D693ED91E79071EB540207196761DC669A6376276EE23EA695C2C6BA4A927DD6069F58B89131F2F23BD4A9773263A91F9D3B8AC6AD154E3BF43C38C7D2ACA488E3E56069887D1451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514521200C9381400535E444196602AB4D7C14ED8C67DCD67CD72D21E4E7D695C65F9EF829C47CFA9AA724ED2312C7AF6AADBC8E9C1A4663D3BD20270FCE37648F434DF3496C0193DAA15DA0F3927DB8A52D9E8847D4F1401209245390483E94EF3263D58E3F3A890303C1C7B0A9048E0F2DFD681922C4AC3E69464F4C1E94A6DB69C89B39FC2A0331CF18CD025E9EB4016D5028E497FC714E6DD8C24600F52D9AA667623A927D698657ECC78F4140EE596DC1B3BB91DF69350B391D093F862A23339182C48A42D9EB9E68112876639EBF853D6420E41C557DC47B629CAF8E8C7E98A0468437CEBC31DC3DEAF453A4A3E53CFA1AC4120E85734F5979013AFA5303768ACB8AF1E361B8E7D6B423956550CA68B88928A28A601451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450035982A927A0ACEBBB9DFC2F0A296F6E77131A1E077ACF67DC7D854B6315E4CF5393DAA3271F5A3760127F0A8F712793400F2D8FF00EBD286E39E47D6A3F7A4C53025C8C64018FAD1E69C60545824F3CD3B1DFBD201DE613ED49B8D26C269769A00507D6827D06285434ED9ED9A2E3B0DC8A6E7D47E7526CF6A42A4F340588C9FAD2679F5A7ECF6A4DA7D281580395FBA067D69A5BD7BD3F67B521534C0457F5A9439E083823A545B4D07038E681132124E0F353C333C0CAC0F155164C74E4D491B162011C7E540CDE86659972A79EE2A5AC486431B7CAD835A10DE2B6049F29F5ED45C2C5BA28A298828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A004AA77B73B01443CF7229F7573E582A879EE7D2B22697269363076E33DCD44CD85C0A467E3DE9B824E2900124D007A0FC6A48E077EC7156E1B4EE686C6914C46C7B54896E7D2B456051DA9C235A9E62B94CF16C7BD28833D05681407B502314AE3B1485BFAD385B7B55C118A76D14EE1629FD9A97ECE3B0AB7B68DB480ABF6718E94D36FED573149B680291B7F6A69871DAAF95148541A2E1633DA1EE69A635EF57DA21E829BE40EC28B858CE284F41C5218BD455F30F3C5061E39A7717299C63C1CE3F1A54CE79AB462E4F14C311F4A771389182DBFE5E952C6FB96A02A55867B1C8A73704B0F5C914C45FB6BC31E11FE65FD4568AB0750CA720D61290C09CF2067EB56ACEE4C6DB58FCA7A8A6988D5A2901C8C8A5A620A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AAF753F949807E63D2A66215493D0563DCCC6490B67F03498D11CD21C13D73DEAA64B3734E7258914E8E3DCF8148371B1C664718ABD15985037726A4B5856304D59E952D96A246B12A8C014F0314B4521894A28C52D21852D20A753109452D25031452D252D021A68A5A28189494EA612338A00752528A2801B4D600F18CD498A4C50045E5E7AD0631E952E29314014E68863A5546560735AE403D6A196DC1191426268CD8CE187A54A40073DA99346636C91DE9EA43807354458D2B09CB8D8C7A74ABB58B6CE62914FA1F5EB5B554890A28A298051451400514514005145140051451400514514005145140051451400514532593CB8CB7E540156FE620794BC93D6B264273C9A9E693962C41CD542C5DB03F3A9DCA1514B370326B42DE0D801C7CDFD69965005F988E6AE01839A96CA480000605145148A168EF49466900B4B499A5A005A5A6D2D30168A4A01A0428A5A4A2800A290D028185211934EA4340082968A4A005CD19A4A4A005A4A292900EA29B9A5A008678830C55178CC4F823E5AD42322AADD46590F14D09A208CEE20F715B10C8B2C608F4E4560C60AB8FEB57ACEE046E327E53C1AB466CD5A28A2A84145145001451450014514500145145001451450014514500145145001597A85CE1F6293C70315A323044663D866B02762CE58D263444774B2609E4D4B6F182703BD3630304F7E9566D863B54B1A2DC40018A90D471D3CD496149452D00252E2928A4316969053B14C02968A2800A314B4500145145002514B4530128A5A2801292968E29009494B450021A6D3CD348A4026694537BD2E71400F069AEA0A9A01A71E94C4664EBB589E7151C6486CAD5ABA4EE2AA29DC40E98F4AA44C8DAB193CCB719EA0E2ACD66E99200CC84F51919AD2AB4405145140051451400514514005145140051451400514514005145140105E7FC7B3F358521E83D6B5B509B188C75EA6B258E0D4F518E41C6315661C01502FCA9D39A9A2E952CA45A8FA0A79A8E13C5499A4509413499A05002F5A5029A580EF51C970A9C753405C9C9C526F1EB549EE9BE95035CC99E7814EC1734FCC007340993FBC3F3AC93292724E694484707A5160B9ABE72E719A77983B1ACB0EDD3A8A9848401CD0172F8704D2E6AA076383DFA54EBD3AD2192D21A6E6826801D9A633E2919B822A26738340121931C9A4F3401B8F53DAABBB6573EA6A3918B1E3A0A626CB5F695EE69E255619078ACC6255BD4F7A69761D18834585735BCC069739ACA5B975EAD9FAD588AECF73458772E914DA62DC29EBC5480861914AC17014EA68A750057B9E4550FB878EB9ABF7078AA6EA0E69A1326B57C5C2B679CF22B6AB9E849535BD0B6F895B39C8AB4663E8A28A6014514500145145001451450014514500145145001451450063DE9DD76C07D2A99E6400559B9606E1C8F5355933BF71A918F27E623D2A446A8339CFAE6A54EB498D1762E952547174CD49525894C96558C633C9A591F6213541D99DC9EB4240D8B24CC58F27EB50B39273DEA410B376A916DC0EB8AA15995B6B1A7089B1CE6AD796076A5DA28B872958211D452ECCF153914DE94AE3B02AD3B03D3DA80D4B9A570B0E5E38A9D1B22AB679CD4D1F4A0648294D2A8A52B4011B1E2A063906A77155DB20D00348EDD714D614EDD485A81588482053191BB0A9B34E1D29DC2C553137A0A4DAC0E40C55CDB46C1E945C5CA551230EB9A9A2B8652307F0A7F940D35A0F40280B58BD148245DC3F11520ACF81DA27C55E5391914AC320B9E2A9B1C03EF576E871545CF38A684C6EEC366B634F94BC6531C2D6337DEC7BF5AD2D29C6F65EE466AD1069D14514C414514500145145001451450014514500145145001451450061DD02B7120F426AB80428F6ABBA82E2E8F1D6A931C0C0A9180E95247C91508A9EDBE67A4C68BD10C28A71A00C0A5ED525905C7CD8515147181DAA66196C9A5200FAD003000297193477A52428CB1C50300B4BB31E95134A4739DA3F5A81AEE307A6F3EA68484D961F60FE2151332F63513DCBF24C6B8FC2A31346FD57069D82E4F9F4A50F5128E3E53914BC834864EA735623AAF17356178A009C529E4546A69FDA80237E955DEAC49D2ABBF0284042C7069B9CD237269361C7270280245D83EF11522188F46AADE64518E82817B8FBA9FA53B0AF62EED4FEF0A4298E9CD5517EA4E1971F854C93238CA360FA52682E3B18A50334A18370DC1EDEF487E5340C6BA67B558B7398FDC530734F8B86340865C7299ACF63CD69DC0C444E3A5661E48A68960A70C6AEE9DFF001F231C8C735440F9BD856869A099F23B0E6AD126AD14514C414514500145145001451450014514500145145001451450065EA80F9CA71D4567B0E6B5B544CC2AC3B1AC86F7A901A2AD598CBE6AAE70B56ECBAD26522F6283F769474A0F4A92C605C531E9E6A363400D6708B9EFE955649C83EAC7F4A95959CF15198141C9C93420609097399093ED55A74D8ED5754B29E0D367884A324E0FA8AAB92D333B2C4019A9ED5034A7238C73529B450A06EE9DC0EB53242B1FCAA7AF7A7705120910C6D94E95342E241861CD4AB129EDF9D48111460019A965A18A8148A9B1C522AF34EC5201E829F4C53814E073400D75E2ABB0CF06AD1A8185005793644B92335589695B9E9E957F62B7DE151B44A3A0C508195A785440768E7BD5239CF0715A857B67F3AAED6C37128D8CF1C8CD5A643894901279E956D60611A9190D8A12D823025B77E153B12DED4360A2C8E1989F91CF3EBE95651B70C37DE155BC804E4673EB534791C30E477A865A27438A9075151AD4A9D28426138CC4C3DAB24F048F7AD894650FD2B1DF8734D12C4073D3B9AD2D2B3E637A639ACD4E3F0AD7D247EE59BD4D5A20BF45145300A28A2800A28A2800A28A2800A28A2800A28A2800A28A280229E3F32074F51C56038EA2BA4AC0BA8CC733AFA1A4C0ADDB156ECBEF555039AB369FEB293291A43A521A51D290D416308CD34AD49498A0647B693654B8A31401118F349E4FBD4E0528140107903BE69E2203A0A9292801B8F6A02F34EC62928B800141A0E71C50064D201CA33CD3E803D294D3018DD2A322A5A8D860D00348A319EB4EA319A008CC79ED4DF27F0A987BD2E050056F2697CBC558DB49B68020D9ED4BB73536D149B6801AA31522F1498A70140315FEE1AC7947EF0FD6B64F2B59130C48DF5AA443235E2B734E03EC88477C9AC315BF6631691E3FBB9AA4413D14514C028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B33568B0565EC7835A754753DAF0637720F4A4C0C73C558B4FF582ABB1C8FC6A7B43F3FD2931A3481E28ED483A506A0D0296928CD03168A33C5266818A3AD2D2502800A5A28A0421A6D2E79C6690D2188326A45C018A8F705149E653116062835009334BE65170B1253586699E67AD289050020A5A43CF22945002D1452FE340C29283499A005A074E69334039A00751DE8CD1408776AC9B91899AB587A564DD9C4E71EB4D12C2DA2324EA83B9ADF550AA00E82B1EC731C9E600338EF5AD1CA1C7A1AB4C96992514514C90A28A2800A28A2800A28A2800A28A2800A28A2800A28A280229E4D89D719AA6C56518073525FB6303DAB3C3953B87159C9EA6D08E9719730F97C8E945A1FDE1F5AB33012DBE4F07AD57B35DB39CF6A6B621AB3346834945494146690D140C5A514945031D45251400A28A07BD14804C0073DE9ACF814E6355A53D68023B8BA58FDCFA5575BF25B063C8F634971096391D696D2D8A82CE39ED4D584EE5C590328228DF4C55DB9C9EB477A0026B948B1BB39F414C8EF12438E41F7A82E60691CB0EB50A42C18669D90B5B9B11BE4629E3A5548490066AD21C8A450EEF451494800D1484E28CD002D149466980B4A0D341A01A04482B26E079972CBEF8AD5C80B9354638F33BCC7A678A689B5C90324002F534E86E8F983231514EB9F9AA343F30A46CA29A3710EE507D452D476FCC2B5256A8E67B8B45145020A28A2800A28A2800A28A2800A28A2800A28A280286A0391F4AA001240AD1BE5E01F6AA5026E939E839ACDEE74C3E1275E0800678A83605B8C8EF534D208D70B5042CC4EF6E99A48892D2E5B078A5A41D28268101A28269074A062E734B4940A005A753452D20168A4A4CD0306E95048A7B54DD7AD211401028C7DE14AC476A7919A8CE071DE810C39CD14E23E6007D4D0579A6171141A193D0734A99DD83D297387DA47E3400D446CF3D2AD27029AA05380A063B3C5145148069A0F5A522928109451499A005A51494A3AD310487119FA543180D1800F22A49DB0B8F5AA4374533007BD0C715765B74FDD9C8AAD1AFCEA2ADC6FBC73512A62623D28354695BFF00AA5A929B10C46A3DA9D5AA395EE2D145140828A28A0028A28A0028A28A0028A28A0028A28A0082E937479F4AA50AEC5627B9AD223208354265D84AFA54497535A72D2C569CE4D083FD1C0F46E69CCB93CD046071528B96C4C84EDA7544871C53FAD04214D00D354E739A502818A29D4D03029D40052D250690051D066933416E3340012719A3A8C8A090451C01CF1400817AD279631C9A3CCC138E94C2DCD31D87B443F87A9A0464E01ED5189083C1A734DC50161E5557A526D53F5A8C3E69D9A0761DB4E7DA9CADEB4D0DCE0D3B8C1C75A09D85068A6027D69C1A905C5A08A052D00348A4A53CD21A6014A2901CD19A044731F9D47BF350BAE5C9F534F7E6519A5C67A50CA804390715285CCDF5C5469F7AAC443330A68A6EC5DE82968A2B439828A28A0028A28A0028A28A0028A28A0028A28A0028A28A002A9DCAE5CD5CAAD748721854CB62A0ECCABE59C64D23467693528CECA4393506B72BC7823767F1F5A954F151020656A453CE0D3210BDA807814873CFA51486480E45029AB4E140C5A42714B452013381CD3588A56C01559E5A009F7719A8DE527E955DE6F534D53249CAAF1EF4EC344FBA91DBF3A8CC339EE0534DBCA4F2C681D8793CF5A378F5A8DADA5C7DE3CD352D1C1E589A632C0714E120F5A856D1BAE4D38DB48BF75B3F5A40C90BE29C92D5563227DE5CFD281303DE8B125E07278A90D52494FAD5989F70E6908968A40734B4009DE9A700538D318D310A30051F4A45148C714011AE0CB9C54EB8CD450E0B9CD4C179C8A18E2248551BA726A6B504B962299B031C9EB56614D89EE69C56A29BD0968A28AD0C828A28A0028A28A0028A28A0028A28A0028A28A0028A28A00291943020D2D140155D36F06A36C62ADC89B87BD5578A4CE00CD4346916533F789C7534E51900E7A549340D1461C9E73D2A35CE381C520EA3F2690F14E1EB4D7C9E94863B77614E0702998C53860D003E90D14D634864721278150B4658601C54F8A5039A00AA96A03658E4FBD5855C74A791CD21000A771A1453B22A22D8A61928B8EE4E718A55602AB7999A3CC1EB45C772C1614D273516FA55393C51715C73007B544F6D1B9C918FA54C3A52918A2E495C5B88F919A9178E69FC1E0D045201EA78A76698BC53C500213CD3783DA9CD48073914C42678A8DF9F6F5A79E0629AAB97C67AF06842608AD1B60822A64CB741571630A8148040E99A70555E800AAE51739145191CB54D452D525625BB8514514C414514500145145001451450014514500145145001451450014514500145145004174BBA16E338159C32BC56B919183599229591948EF5322A2049140E949D57E94A0E4541614E5E291460734B400B9E29A6969290C052D368CD002E6909CD045277A00693ED4C7E78A976D1E5E680B15B04669002455B118A0443B50162B00453D491536C029365170B080D2F514628A402D14514C05A70F5A68A70E94083834838A5A298098C9A5B74CCA3BF3CD34F078AB16A87717C7078A684CB745145686614514500145145001451450014514500145145001451450014514500145145001451450014514500154EF100218753D6AE5472A09108EFDA931A33B380680D9E691C60F5F6A503F2ACCD10F145203477A0028A28A43128A762971400DC518A76296801BB4D382D28E946681863028E693A7AD1B85001DA9A54D3B3470680198A4C54845262810CA5A31450028A51494502168345230C8A602282CC00EF5A08BB500F4155AD6339DC46455CAB8A21B0A28A2A890A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A28033E740AEDC5423238CD5AB81F39AACC39E2B266885A5A6E7D68CD031D4A29B9A01A007D029A0D2E45031D9A4270693346EC8CD003B3499E2A367E7E94DDFD79A02E4A4F14C0DC1EF4C0FD8D34B00C31DE815C9F7702941A8031C734E0FC0340C989A2A20FD69770C726815C9293BD30C946EF5A007D14DCD2F5A00514BDC0A3A52A019CD022E42A16318A929A9F717E94EAD4CC28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00AB73F7FF0AAEC2ACDCFDE1F4AAE6B27B9A2D889877A6938C54869840EB40C40F4BBAA3DA4671D28C91EF400F2DE94D0FCFB5217078A4CE05003D9F271DA93CDF94F350B73D2A3CE0617F3A009CC98148AE33906A0663938A01C2D315CB1BB2734D0D939350F9986C52A9F9A815C9C3E00A37E075A80B12D81DA9325463D3BD03B938900049EB485C91500C9393D29CB93C5004E1B81CF5A7AB6E02A2552DC76152A8C0A431EB4ECF614D033D69EA31400E14F5A68A72D005E5FBA3E94B4D4FB83E94EAD4C828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00AD73F787D2A0353DCFDE1F4AAC33DEB296E691D843494E34DA06318531871C0A96908CD0043E58C7419A694602A53C52119E940158871DA9AC4FA11F855A233DE90A8F4A2E162A82BCE4FE74A4A8E98A9FCB07B629BE52E7FA5171588004F5146E1BB8353794BD314A17078029DC2C45B864050734139180B536D14E09ED4AE1620D8C78518A9522C753D6A40B81814A05171D815000714F5031405F5A70A0000A70A4A70A00514E5EB4D14AB4017A3FB8BF4A75322FF005629F5AA320A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2802B5CFDE1F4A82A7B8FBFF85406B27B9A476129B8A71A4A063690D3A92801845211E829E462908A008C8A39A76290D00276A4C53B1498A0043498A7629B8E7AD002629E2931ED4A050028A70A4029C050020A7502971400B4A28A5A005142D02945005A87EE7E352D416E7822A7AD16C66F70A28A298828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A4A5A0028A28A0028A28A0028A28A0028A28A00AB71F7EA2A92720B9A8EB27B9AAD869A434EA4A0069A2969280131494EA4A006D2629D8A4A00691453B14D2280131498A7518A004A5C518A51400014E1D2900A70A002968A28016945252D0028A0502968193C07E6C558AA901C482ADD5C763396E14514551214514500145145001451450014514500145145001494514005145140052D252D00145252D00145145001504F2EDF941C134F790271DFD2A9B36E959AA64CA48563934946734541614514500252529A2801B8A4C53A8C500368C53A8C50032908A711498A006D18A7628C50036969714B8A00414E14A05140051452E28010528A314B40052D251DE80154F35622972421FCEAB03CD2B74FA534EC26AE5FA2A38E40EA0F426A4AD0CC28A28A0028A28A0028A28A0028A28A0028A28A004A28A2800A28A2800A5A28A002928A2801691BEE9A28A00A9FC7F8D42BD0FD68A2B36688777A28A290C28A28A004ED4945140052D145001451450021A4ED451400945145002F7A51451400B49451400A281451400B4514500149DE8A2801452F6A28A403E1FB82A662772F27A51456912195CB379FF0078FE756D3EED1455087D145140828A28A0028A28A0028A28A00FFFD9"));
            new BerTLVView(new[] { berTlv }).View();
            //var res = Encoding.UTF8
            //    .GetString(
            //        new BinaryHex(
            //            //((HelloWord.BerTLV)berTlv.Data[3]).Val
            //            berTlv
            //                .Data
            //                .First()
            //                .Val
            //        ).Bytes()
            //    );

            return string.Empty;
        }
    }
}
