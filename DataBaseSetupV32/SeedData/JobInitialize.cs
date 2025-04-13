using DataBaseSetupV3.Model;
using DataBaseSetupV3.SeedData;
using System;
using System.Collections.Generic;
using System.Threading;
namespace DataBaseSetupV3
{
	public static class JobInitialize
    {
		public static DataBaseContext context = Configurations.GetDataBaseContext();
		public static void JobInitializeSeedData()
        {
			string mainComId = SystemData.CreateMainComId();
			string IndustryId = SystemData.GetIndustryId();
			if(IndustryId == "IN60006")
			{ 
				#region  Initialize seed data
				var Jobs = new List<Job>
				{
					 new Job{ JobId ="J0001" , The3rdJobId ="J0001", JobName ="",EnJobName= LangAuto.Auto("地渠及喉管工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0002" , The3rdJobId ="J00010", JobName ="",EnJobName=LangAuto.Auto("瀝青工(道路建造)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0003" , The3rdJobId ="J000100", JobName ="",EnJobName=LangAuto.Auto("鋪瓦工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0004" , The3rdJobId ="J000101", JobName ="",EnJobName=LangAuto.Auto("鋪瓦工(紙皮石)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0005" , The3rdJobId ="J000102", JobName ="",EnJobName=LangAuto.Auto("鋪瓦工(瓷瓦)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0006" , The3rdJobId ="J000103", JobName ="",EnJobName=LangAuto.Auto("鋪軌工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0007" , The3rdJobId ="J000104", JobName ="",EnJobName=LangAuto.Auto("建造貨運車輛駕駛員(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0008" , The3rdJobId ="J000105", JobName ="",EnJobName=LangAuto.Auto("重型貨車駕駛員"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J0009" , The3rdJobId ="J000106", JobName ="",EnJobName=LangAuto.Auto("特別用途車輛駕駛員"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00010" , The3rdJobId ="J000107", JobName ="", EnJobName= LangAuto.Auto("中型貨車駕駛員"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00011" , The3rdJobId ="J000108", JobName ="", EnJobName= LangAuto.Auto("掛接式車輛駕駛員"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00012" , The3rdJobId ="J000109", JobName ="", EnJobName= LangAuto.Auto("窗框工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00013" , The3rdJobId ="J00011", JobName ="", EnJobName=LangAuto.Auto("幕牆及玻璃工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00014" , The3rdJobId ="J000110", JobName ="", EnJobName=LangAuto.Auto("隧道工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00015" , The3rdJobId ="J000111", JobName ="", EnJobName=LangAuto.Auto("清拆石棉工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00016" , The3rdJobId ="J000112", JobName ="", EnJobName=LangAuto.Auto("手挖沉箱工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00017" , The3rdJobId ="J000113", JobName ="", EnJobName=LangAuto.Auto("地磚鋪砌工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00018" , The3rdJobId ="J000114", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(拆卸) - 挖掘機"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00019" , The3rdJobId ="J000115", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(吊船)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00020" , The3rdJobId ="J000116", JobName ="", EnJobName=LangAuto.Auto("假天花工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00021" , The3rdJobId ="J000117", JobName ="", EnJobName=LangAuto.Auto("間隔(金屬架)工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00022" , The3rdJobId ="J000118", JobName ="", EnJobName=LangAuto.Auto("泥水工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00023" , The3rdJobId ="J000119", JobName ="", EnJobName=LangAuto.Auto("金屬鋼鐵工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00024" , The3rdJobId ="J00012", JobName ="", EnJobName=LangAuto.Auto("竹棚工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00025" , The3rdJobId ="J000120", JobName ="", EnJobName=LangAuto.Auto("棚架工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00026" , The3rdJobId ="J000121", JobName ="", EnJobName=LangAuto.Auto("防水工(燒膠型瀝青氈)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00027" , The3rdJobId ="J000122", JobName ="", EnJobName=LangAuto.Auto("瀝青工(道路建造)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00028" , The3rdJobId ="J000123", JobName ="", EnJobName=LangAuto.Auto("幕牆及玻璃工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00029" , The3rdJobId ="J000124", JobName ="", EnJobName=LangAuto.Auto("竹棚工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00030" , The3rdJobId ="J000125", JobName ="", EnJobName=LangAuto.Auto("鋼筋屈紮工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00031" , The3rdJobId ="J000126", JobName ="", EnJobName=LangAuto.Auto("砌磚工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00032" , The3rdJobId ="J000127", JobName ="", EnJobName=LangAuto.Auto("木模板工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00033" , The3rdJobId ="J000128", JobName ="", EnJobName=LangAuto.Auto("木模板工(樓宇工程)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00034" , The3rdJobId ="J000129", JobName ="", EnJobName=LangAuto.Auto("木模板工(土木工程)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00035" , The3rdJobId ="J00013", JobName ="", EnJobName=LangAuto.Auto("鋼筋屈紮工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00036" , The3rdJobId ="J000130", JobName ="", EnJobName=LangAuto.Auto("混凝土工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00037" , The3rdJobId ="J000131", JobName ="", EnJobName=LangAuto.Auto("建造機械技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00038" , The3rdJobId ="J000132", JobName ="", EnJobName=LangAuto.Auto("幕牆工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00039" , The3rdJobId ="J000133", JobName ="", EnJobName=LangAuto.Auto("地渠工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00040" , The3rdJobId ="J000134", JobName ="", EnJobName=LangAuto.Auto("鋪地板工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00041" , The3rdJobId ="J000135", JobName ="", EnJobName=LangAuto.Auto("鋪地板工(塑料地板)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00042" , The3rdJobId ="J000136", JobName ="", EnJobName=LangAuto.Auto("鋪地板工(木地板)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00043" , The3rdJobId ="J000137", JobName ="", EnJobName=LangAuto.Auto("普通焊接工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00044" , The3rdJobId ="J000138", JobName ="", EnJobName=LangAuto.Auto("玻璃工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00045" , The3rdJobId ="J000139", JobName ="", EnJobName=LangAuto.Auto("岩土勘探工/ 鑽井工/ 鑽孔工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00046" , The3rdJobId ="J00014", JobName ="", EnJobName=LangAuto.Auto("砌磚工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00047" , The3rdJobId ="J000140", JobName ="", EnJobName=LangAuto.Auto("細木工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00048" , The3rdJobId ="J000141", JobName ="", EnJobName=LangAuto.Auto("平水工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00049" , The3rdJobId ="J000142", JobName ="", EnJobName=LangAuto.Auto("雲石工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00050" , The3rdJobId ="J000143", JobName ="", EnJobName=LangAuto.Auto("雲石工(乾掛)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00051" , The3rdJobId ="J000144", JobName ="", EnJobName=LangAuto.Auto("雲石工(濕掛)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00052" , The3rdJobId ="J000145", JobName ="", EnJobName=LangAuto.Auto("雲石工(打磨)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00053" , The3rdJobId ="J000146", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊運)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00054" , The3rdJobId ="J000147", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊臂 - 夾吊)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00055" , The3rdJobId ="J000148", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊臂 - 鈎吊)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00056" , The3rdJobId ="J000149", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊桿)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00057" , The3rdJobId ="J00015", JobName ="", EnJobName=LangAuto.Auto("木工(護木)"),IndustryId="IN60006",IndustryName =LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00058" , The3rdJobId ="J000150", JobName ="", EnJobName=LangAuto.Auto("砌石工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00059" , The3rdJobId ="J000151", JobName ="", EnJobName=LangAuto.Auto("金屬棚架工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00060" , The3rdJobId ="J000152", JobName ="", EnJobName=LangAuto.Auto("金屬工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00061" , The3rdJobId ="J000153", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00062" , The3rdJobId ="J000154", JobName ="", EnJobName=LangAuto.Auto("打樁工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00063" , The3rdJobId ="J000155", JobName ="", EnJobName=LangAuto.Auto("打樁工(鑽孔樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00064" , The3rdJobId ="J000156", JobName ="", EnJobName=LangAuto.Auto("打樁工(撞擊式樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00065" , The3rdJobId ="J000157", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(建築工地升降機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00066" , The3rdJobId ="J000158", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(打樁)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00067" , The3rdJobId ="J000159", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(鑽孔樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00068" , The3rdJobId ="J00016", JobName ="", EnJobName=LangAuto.Auto("木模板工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00069" , The3rdJobId ="J000160", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(撞擊式樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00070" , The3rdJobId ="J000161", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(隧道) - 鑽孔機"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00071" , The3rdJobId ="J000162", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(隧道) - 拱塊安裝"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00072" , The3rdJobId ="J000163", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(隧道) - 鑽挖機械"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00073" , The3rdJobId ="J000164", JobName ="", EnJobName=LangAuto.Auto("批盪工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00074" , The3rdJobId ="J000165", JobName ="", EnJobName=LangAuto.Auto("批盪工(盪地台)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00075" , The3rdJobId ="J000166", JobName ="", EnJobName=LangAuto.Auto("水喉工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00076" , The3rdJobId ="J000167", JobName ="", EnJobName=LangAuto.Auto("索具工(叻㗎)/ 金屬模板裝嵌工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00077" , The3rdJobId ="J000168", JobName ="", EnJobName=LangAuto.Auto("結構鋼架工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00078" , The3rdJobId ="J000169", JobName ="", EnJobName=LangAuto.Auto("鋪瓦工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00079" , The3rdJobId ="J00017", JobName ="", EnJobName=LangAuto.Auto("木模板工(樓宇工程)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00080" , The3rdJobId ="J000170", JobName ="", EnJobName=LangAuto.Auto("鋪瓦工(紙皮石)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00081" , The3rdJobId ="J000171", JobName ="", EnJobName=LangAuto.Auto("鋪瓦工(瓷瓦)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00082" , The3rdJobId ="J000172", JobName ="", EnJobName=LangAuto.Auto("窗框工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00083" , The3rdJobId ="J000173", JobName ="", EnJobName=LangAuto.Auto("手挖沉箱工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00084" , The3rdJobId ="J000174", JobName ="", EnJobName=LangAuto.Auto("噴塗油漆工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00085" , The3rdJobId ="J000175", JobName ="", EnJobName=LangAuto.Auto("假天花工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00086" , The3rdJobId ="J000176", JobName ="", EnJobName=LangAuto.Auto("機械設備技工(建造工作)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00087" , The3rdJobId ="J000177", JobName ="", EnJobName=LangAuto.Auto("機械設備技工(建造工作)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00088" , The3rdJobId ="J000178", JobName ="", EnJobName=LangAuto.Auto("強電流電纜接駁技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00089" , The3rdJobId ="J000179", JobName ="", EnJobName=LangAuto.Auto("電子設備技工(建造工作)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00090" , The3rdJobId ="J00018", JobName ="", EnJobName=LangAuto.Auto("木模板工(土木工程)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00091" , The3rdJobId ="J000180", JobName ="", EnJobName=LangAuto.Auto("強電流電纜接駁技工(低壓)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00092" , The3rdJobId ="J000181", JobName ="", EnJobName=LangAuto.Auto("強電流電纜接駁技工(無通電電纜)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00093" , The3rdJobId ="J000182", JobName ="", EnJobName=LangAuto.Auto("電氣裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00094" , The3rdJobId ="J000183", JobName ="", EnJobName=LangAuto.Auto("控制板裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00095" , The3rdJobId ="J000184", JobName ="", EnJobName=LangAuto.Auto("電氣佈線工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00096" , The3rdJobId ="J000185", JobName ="", EnJobName=LangAuto.Auto("消防設備技工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00097" , The3rdJobId ="J000186", JobName ="", EnJobName=LangAuto.Auto("消防電氣裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00098" , The3rdJobId ="J000187", JobName ="", EnJobName=LangAuto.Auto("消防機械裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J00099" , The3rdJobId ="J000188", JobName ="", EnJobName=LangAuto.Auto("手提消防設備裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000100" , The3rdJobId ="J000189", JobName ="", EnJobName=LangAuto.Auto("升降機及自動梯技工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000101" , The3rdJobId ="J00019", JobName ="", EnJobName=LangAuto.Auto("木模板工(樓宇工程)(拆板)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000102" , The3rdJobId ="J000190", JobName ="", EnJobName=LangAuto.Auto("升降機技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000103" , The3rdJobId ="J000191", JobName ="", EnJobName=LangAuto.Auto("自動梯技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000104" , The3rdJobId ="J000192", JobName ="", EnJobName=LangAuto.Auto("機械打磨裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000105" , The3rdJobId ="J000193", JobName ="", EnJobName=LangAuto.Auto("架空電線技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000106" , The3rdJobId ="J000194", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000107" , The3rdJobId ="J000195", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(送風系統)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000108" , The3rdJobId ="J000196", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(電力控制)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000109" , The3rdJobId ="J000197", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(保溫)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000110" , The3rdJobId ="J000198", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(獨立系統)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000111" , The3rdJobId ="J000199", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(水系統)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000112" , The3rdJobId ="J0002", JobName ="", EnJobName=LangAuto.Auto("泥水工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000113" , The3rdJobId ="J00020", JobName ="", EnJobName=LangAuto.Auto("木模板工(土木工程)(拆板)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000114" , The3rdJobId ="J000200", JobName ="", EnJobName=LangAuto.Auto("建築物防盜系統技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000115" , The3rdJobId ="J000201", JobName ="", EnJobName=LangAuto.Auto("電訊系統裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000116" , The3rdJobId ="J000202", JobName ="", EnJobName=LangAuto.Auto("氣體裝置技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000117" , The3rdJobId ="J000203", JobName ="", EnJobName=LangAuto.Auto("電子設備技工(建造工作)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000118" , The3rdJobId ="J000204", JobName ="", EnJobName=LangAuto.Auto("控制板裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000119" , The3rdJobId ="J000205", JobName ="", EnJobName=LangAuto.Auto("電氣佈線工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000120" , The3rdJobId ="J000206", JobName ="", EnJobName=LangAuto.Auto("消防電氣裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000121" , The3rdJobId ="J000207", JobName ="", EnJobName=LangAuto.Auto("消防機械裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000122" , The3rdJobId ="J000208", JobName ="", EnJobName=LangAuto.Auto("機械打磨裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000123" , The3rdJobId ="J000209", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(送風系統)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000124" , The3rdJobId ="J00021", JobName ="", EnJobName=LangAuto.Auto("混凝土修補工(混凝土剝落)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000125" , The3rdJobId ="J000210", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(電力控制)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000126" , The3rdJobId ="J000211", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(保溫)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000127" , The3rdJobId ="J000212", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(獨立系統)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000128" , The3rdJobId ="J000213", JobName ="", EnJobName=LangAuto.Auto("空調製冷設備技工(水系統)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000129" , The3rdJobId ="J000214", JobName ="", EnJobName=LangAuto.Auto("建築物防盜系統技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000130" , The3rdJobId ="J000215", JobName ="", EnJobName=LangAuto.Auto("電訊系統裝配工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000131" , The3rdJobId ="J000216", JobName ="", EnJobName=LangAuto.Auto("E425"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000132" , The3rdJobId ="J000217", JobName ="", EnJobName=LangAuto.Auto("E426"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000133" , The3rdJobId ="J000218", JobName ="", EnJobName=LangAuto.Auto("E427"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000134" , The3rdJobId ="J000219", JobName ="", EnJobName=LangAuto.Auto("強制性基本安全訓練課程(平安咭)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000135" , The3rdJobId ="J00022", JobName ="", EnJobName=LangAuto.Auto("混凝土工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000136" , The3rdJobId ="J000220", JobName ="", EnJobName=LangAuto.Auto(""),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000137" , The3rdJobId ="J00023", JobName ="", EnJobName=LangAuto.Auto("建造機械技工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000138" , The3rdJobId ="J00024", JobName ="", EnJobName=LangAuto.Auto("幕牆工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000139" , The3rdJobId ="J00025", JobName ="", EnJobName=LangAuto.Auto("拆卸工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000140" , The3rdJobId ="J00026", JobName ="", EnJobName=LangAuto.Auto("拆卸工(建築物)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000141" , The3rdJobId ="J00027", JobName ="", EnJobName=LangAuto.Auto("拆卸工(違例建築工程)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000142" , The3rdJobId ="J00028", JobName ="", EnJobName=LangAuto.Auto("潛水員(建造工作)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000143" , The3rdJobId ="J00029", JobName ="", EnJobName=LangAuto.Auto("地渠工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000144" , The3rdJobId ="J0003", JobName ="", EnJobName=LangAuto.Auto("防水工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000145" , The3rdJobId ="J00030", JobName ="", EnJobName=LangAuto.Auto("鋪地板工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000146" , The3rdJobId ="J00031", JobName ="", EnJobName=LangAuto.Auto("鋪地板工(塑料地板)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000147" , The3rdJobId ="J00032", JobName ="", EnJobName=LangAuto.Auto("鋪地板工(木地板)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000148" , The3rdJobId ="J00033", JobName ="", EnJobName=LangAuto.Auto("普通焊接工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000149" , The3rdJobId ="J00034", JobName ="", EnJobName=LangAuto.Auto("玻璃工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000150" , The3rdJobId ="J00035", JobName ="", EnJobName=LangAuto.Auto("岩土勘探工/ 鑽井工/ 鑽孔工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000151" , The3rdJobId ="J00036", JobName ="", EnJobName=LangAuto.Auto("灌漿工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000152" , The3rdJobId ="J00037", JobName ="", EnJobName=LangAuto.Auto("細木工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000153" , The3rdJobId ="J00038", JobName ="", EnJobName=LangAuto.Auto("細木工(組裝)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000154" , The3rdJobId ="J00039", JobName ="", EnJobName=LangAuto.Auto("平水工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000155" , The3rdJobId ="J0004", JobName ="", EnJobName=LangAuto.Auto("金屬鋼鐵工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000156" , The3rdJobId ="J00040", JobName ="", EnJobName=LangAuto.Auto("雲石工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000157" , The3rdJobId ="J00041", JobName ="", EnJobName=LangAuto.Auto("雲石工(乾掛)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000158" , The3rdJobId ="J00042", JobName ="", EnJobName=LangAuto.Auto("雲石工(濕掛)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000159" , The3rdJobId ="J00043", JobName ="", EnJobName=LangAuto.Auto("雲石工(打磨)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000160" , The3rdJobId ="J00044", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊運)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000161" , The3rdJobId ="J00045", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊臂 - 夾吊)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000162" , The3rdJobId ="J00046", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊臂 - 鈎吊)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000163" , The3rdJobId ="J00047", JobName ="", EnJobName=LangAuto.Auto("海面建造機械操作工(吊桿)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000164" , The3rdJobId ="J00048", JobName ="", EnJobName=LangAuto.Auto("砌石工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000165" , The3rdJobId ="J00049", JobName ="", EnJobName=LangAuto.Auto("金屬棚架工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000166" , The3rdJobId ="J0005", JobName ="", EnJobName=LangAuto.Auto("混凝土及灌漿工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000167" , The3rdJobId ="J00050", JobName ="", EnJobName=LangAuto.Auto("金屬工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000168" , The3rdJobId ="J00051", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000169" , The3rdJobId ="J00052", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(內外牆轆油)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000170" , The3rdJobId ="J00053", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(批填漆灰)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000171" , The3rdJobId ="J00054", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(髹乳膠漆)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000172" , The3rdJobId ="J00055", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(髹手掃漆)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000173" , The3rdJobId ="J00056", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(髹油基漆)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000174" , The3rdJobId ="J00057", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(髹透明纖維素漆)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000175" , The3rdJobId ="J00058", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(噴塗油漆)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000176" , The3rdJobId ="J00059", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(鐵器噴漆)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000177" , The3rdJobId ="J0006", JobName ="", EnJobName=LangAuto.Auto("棚架工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000178" , The3rdJobId ="J00060", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(裱貼牆纸)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000179" , The3rdJobId ="J00061", JobName ="", EnJobName=LangAuto.Auto("髹漆及裝飾工(繪寫字體)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000180" , The3rdJobId ="J00062", JobName ="", EnJobName=LangAuto.Auto("打樁工(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000181" , The3rdJobId ="J00063", JobName ="", EnJobName=LangAuto.Auto("打樁工(鑽孔樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000182" , The3rdJobId ="J00064", JobName ="", EnJobName=LangAuto.Auto("打樁工(撞擊式樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000183" , The3rdJobId ="J00065", JobName ="", EnJobName=LangAuto.Auto("敷喉管工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000184" , The3rdJobId ="J00066", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(建築工地升降機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000185" , The3rdJobId ="J00067", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(推土機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000186" , The3rdJobId ="J00068", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(挖掘機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000187" , The3rdJobId ="J00069", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(搬土機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000188" , The3rdJobId ="J0007", JobName ="", EnJobName=LangAuto.Auto("防水工(黏貼型瀝青氈)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000189" , The3rdJobId ="J00070", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(小型裝載機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000190" , The3rdJobId ="J00071", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(小型裝載機(連配件))"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000191" , The3rdJobId ="J00072", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(叉式起重車)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000192" , The3rdJobId ="J00073", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(平土機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000193" , The3rdJobId ="J00074", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(傾卸車)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000194" , The3rdJobId ="J00075", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(機車)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000195" , The3rdJobId ="J00076", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(壓實機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000196" , The3rdJobId ="J00077", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(鏟運機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000197" , The3rdJobId ="J00078", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(履帶式固定吊臂起重機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000198" , The3rdJobId ="J00079", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(龍門式起重機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000199" , The3rdJobId ="J0008", JobName ="", EnJobName=LangAuto.Auto("防水工(燒膠型瀝青氈)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000200" , The3rdJobId ="J00080", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(塔式起重機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000201" , The3rdJobId ="J00081", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(貨車吊機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000202" , The3rdJobId ="J00082", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(輪胎式液壓伸縮吊臂起重機)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000203" , The3rdJobId ="J00083", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(打樁)(全科)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000204" , The3rdJobId ="J00084", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(鑽孔樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000205" , The3rdJobId ="J00085", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(撞擊式樁)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000206" , The3rdJobId ="J00086", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(隧道) - 鑽孔機"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000207" , The3rdJobId ="J00087", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(隧道) - 機車操作"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000208" , The3rdJobId ="J00088", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(隧道) - 拱塊安裝"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000209" , The3rdJobId ="J00089", JobName ="", EnJobName=LangAuto.Auto("機械設備操作工(隧道) - 鑽挖機械"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000210" , The3rdJobId ="J0009", JobName ="", EnJobName=LangAuto.Auto("防水工(塗膜)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000211" , The3rdJobId ="J00090", JobName ="", EnJobName=LangAuto.Auto("批盪工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000212" , The3rdJobId ="J00091", JobName ="", EnJobName=LangAuto.Auto("批盪工(盪地台)"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000213" , The3rdJobId ="J00092", JobName ="", EnJobName=LangAuto.Auto("水喉工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000214" , The3rdJobId ="J00093", JobName ="", EnJobName=LangAuto.Auto("鑽破工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000215" , The3rdJobId ="J00094", JobName ="", EnJobName=LangAuto.Auto("預應力(拉力) 工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000216" , The3rdJobId ="J00095", JobName ="", EnJobName=LangAuto.Auto("索具工(叻㗎)/ 金屬模板裝嵌工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000217" , The3rdJobId ="J00096", JobName ="", EnJobName=LangAuto.Auto("噴射混凝土工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000218" , The3rdJobId ="J00097", JobName ="", EnJobName=LangAuto.Auto("爆石工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000219" , The3rdJobId ="J00098", JobName ="", EnJobName=LangAuto.Auto("結構鋼架工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") },
					 new Job{ JobId ="J000220" , The3rdJobId ="J00099", JobName ="", EnJobName=LangAuto.Auto("結構鋼材焊接工"),IndustryId="IN60006",IndustryName=LangAuto.Auto("建造業") }
				};
			
				int i = 0;
				Jobs.ForEach(a =>
				{
					i++;
					a.JobId = string.Format("{0}M{1}",a.JobId, mainComId);
					a.MainComId = mainComId;
				});
				Jobs.ForEach(a =>
				{
					a.JobName = a.EnJobName;
					if (context.Job.Find(a.JobId) ==null)
					{ 
						context.Job.Add(a);
						Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} {3}", a.JobId, a.The3rdJobId, a.JobName, a.EnJobName));
					}
					else
					{
						Console.WriteLine(string.Format("EXISTS : {0} {1} {2} {3}", a.JobId, a.The3rdJobId, a.JobName, a.EnJobName ));
					}
					int delay =100;
	#if DEBUG
					delay = 50;
	#endif
					Thread.Sleep(delay);
				}); 
				context.SaveChanges();
                #endregion
            }
            else //其他则输入默认 OtherWise Enter default value
            { 
				var industry = context.Industry.Find(IndustryId);
				var job = new Job { JobId = mainComId + "J0001", The3rdJobId = "J0001", JobName = "JobName1", EnJobName = "Job Name1", IndustryId = IndustryId, IndustryName = industry?.IndustryName ?? string.Empty, MainComId = mainComId };
				 
				context.Job.Add(job);
				bool res = context.SaveChanges() > 0;
				if(res)
                {
					Console.WriteLine(string.Format("[SUCCESS][JOB ADD] : {0} {1} {2} {3} {4}", job.JobId, job.The3rdJobId, job.JobName, job.IndustryName,job.MainComId));
				}else
                {
					Console.WriteLine(string.Format("[FAIL] [JOB ADD] : {0} {1} {2} {3} {4}", job.JobId, job.The3rdJobId, job.JobName, job.IndustryName, job.MainComId));
				}
				 
			}
		}
    } 
}
