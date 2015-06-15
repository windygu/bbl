﻿
var CityCount,ProvinceCount;
arrProvince = new Array();
arrProvince[0]=new Array('安徽', 1);
arrProvince[1]=new Array('澳门', 2);
arrProvince[2]=new Array('北京', 3);
arrProvince[3]=new Array('福建', 4);
arrProvince[4]=new Array('甘肃', 5);
arrProvince[5]=new Array('广东', 6);
arrProvince[6]=new Array('广西', 7);
arrProvince[7]=new Array('贵州', 8);
arrProvince[8]=new Array('海南', 9);
arrProvince[9]=new Array('河北', 10);
arrProvince[10]=new Array('河南', 11);
arrProvince[11]=new Array('黑龙江', 12);
arrProvince[12]=new Array('湖北', 13);
arrProvince[13]=new Array('湖南', 14);
arrProvince[14]=new Array('吉林', 15);
arrProvince[15]=new Array('江苏', 16);
arrProvince[16]=new Array('江西', 17);
arrProvince[17]=new Array('辽宁', 18);
arrProvince[18]=new Array('内蒙古', 19);
arrProvince[19]=new Array('宁夏', 20);
arrProvince[20]=new Array('青海', 21);
arrProvince[21]=new Array('山东', 22);
arrProvince[22]=new Array('山西', 23);
arrProvince[23]=new Array('陕西', 24);
arrProvince[24]=new Array('上海', 25);
arrProvince[25]=new Array('四川', 26);
arrProvince[26]=new Array('台湾', 27);
arrProvince[27]=new Array('天津', 28);
arrProvince[28]=new Array('西藏', 29);
arrProvince[29]=new Array('香港', 30);
arrProvince[30]=new Array('新疆', 31);
arrProvince[31]=new Array('云南', 32);
arrProvince[32]=new Array('浙江', 33);
arrProvince[33]=new Array('重庆', 34);
ProvinceCount = 34;

function BindProvinceList(ProvinceTextId) {
    var Obj = document.getElementById(ProvinceTextId);
    Obj.length = 0;
    Obj.options[0] = new Option('请选择', 0);
    var index=1;
    for(var i=0; i<ProvinceCount; i++)
    {
        Obj.options[index]=new Option(arrProvince[i][0],arrCity[i][1]);
        index=index+1;
    }
}
arrCity = new Array();

arrCity[0]=new Array('安庆', 1, 1);
arrCity[1]=new Array('蚌埠', 2, 1);
arrCity[2]=new Array('巢湖', 3, 1);
arrCity[3]=new Array('池州', 4, 1);
arrCity[4]=new Array('滁州', 5, 1);
arrCity[5]=new Array('阜阳', 6, 1);
arrCity[6]=new Array('毫州', 7, 1);
arrCity[7]=new Array('合肥', 8, 1);
arrCity[8]=new Array('淮北', 9, 1);
arrCity[9]=new Array('淮南', 10, 1);
arrCity[10]=new Array('黄山', 11, 1);
arrCity[11]=new Array('六安', 12, 1);
arrCity[12]=new Array('马鞍山', 13, 1);
arrCity[13]=new Array('宿州', 14, 1);
arrCity[14]=new Array('铜陵', 15, 1);
arrCity[15]=new Array('芜湖', 16, 1);
arrCity[16]=new Array('宣城', 17, 1);
arrCity[17]=new Array('澳门', 18, 2);
arrCity[18]=new Array('北京', 19, 3);
arrCity[19]=new Array('福州', 20, 4);
arrCity[20]=new Array('龙岩', 21, 4);
arrCity[21]=new Array('南平', 22, 4);
arrCity[22]=new Array('宁德', 23, 4);
arrCity[23]=new Array('莆田', 24, 4);
arrCity[24]=new Array('泉州', 25, 4);
arrCity[25]=new Array('三明', 26, 4);
arrCity[26]=new Array('武夷山', 27, 4);
arrCity[27]=new Array('厦门', 28, 4);
arrCity[28]=new Array('漳州', 29, 4);
arrCity[29]=new Array('白银', 30, 5);
arrCity[30]=new Array('定西', 31, 5);
arrCity[31]=new Array('敦煌', 32, 5);
arrCity[32]=new Array('甘南', 33, 5);
arrCity[33]=new Array('嘉峪关', 34, 5);
arrCity[34]=new Array('金昌', 35, 5);
arrCity[35]=new Array('酒泉', 36, 5);
arrCity[36]=new Array('兰州', 37, 5);
arrCity[37]=new Array('临夏', 38, 5);
arrCity[38]=new Array('陇南', 39, 5);
arrCity[39]=new Array('平凉', 40, 5);
arrCity[40]=new Array('庆阳', 41, 5);
arrCity[41]=new Array('天水', 42, 5);
arrCity[42]=new Array('武威', 43, 5);
arrCity[43]=new Array('张掖', 44, 5);
arrCity[44]=new Array('潮州', 45, 6);
arrCity[45]=new Array('东莞', 46, 6);
arrCity[46]=new Array('佛山', 47, 6);
arrCity[47]=new Array('广州', 48, 6);
arrCity[48]=new Array('河源', 49, 6);
arrCity[49]=new Array('惠州', 50, 6);
arrCity[50]=new Array('江门', 51, 6);
arrCity[51]=new Array('揭阳', 52, 6);
arrCity[52]=new Array('茂名', 53, 6);
arrCity[53]=new Array('梅州', 54, 6);
arrCity[54]=new Array('清远', 55, 6);
arrCity[55]=new Array('汕头', 56, 6);
arrCity[56]=new Array('汕尾', 57, 6);
arrCity[57]=new Array('韶关', 58, 6);
arrCity[58]=new Array('深圳', 59, 6);
arrCity[59]=new Array('阳江', 60, 6);
arrCity[60]=new Array('云浮', 61, 6);
arrCity[61]=new Array('湛江', 62, 6);
arrCity[62]=new Array('肇庆', 63, 6);
arrCity[63]=new Array('中山', 64, 6);
arrCity[64]=new Array('珠海', 65, 6);
arrCity[65]=new Array('百色', 66, 7);
arrCity[66]=new Array('北海', 67, 7);
arrCity[67]=new Array('崇左', 68, 7);
arrCity[68]=new Array('防城港', 69, 7);
arrCity[69]=new Array('贵港', 70, 7);
arrCity[70]=new Array('桂林', 71, 7);
arrCity[71]=new Array('河池', 72, 7);
arrCity[72]=new Array('贺州', 73, 7);
arrCity[73]=new Array('来宾', 74, 7);
arrCity[74]=new Array('柳州', 75, 7);
arrCity[75]=new Array('南宁', 76, 7);
arrCity[76]=new Array('钦州', 77, 7);
arrCity[77]=new Array('梧州', 78, 7);
arrCity[78]=new Array('玉林', 79, 7);
arrCity[79]=new Array('安顺', 80, 8);
arrCity[80]=new Array('毕节', 81, 8);
arrCity[81]=new Array('贵阳', 82, 8);
arrCity[82]=new Array('六盘水', 83, 8);
arrCity[83]=new Array('黔东', 84, 8);
arrCity[84]=new Array('黔南', 85, 8);
arrCity[85]=new Array('黔西', 86, 8);
arrCity[86]=new Array('铜仁', 87, 8);
arrCity[87]=new Array('遵义', 88, 8);
arrCity[88]=new Array('白沙', 89, 9);
arrCity[89]=new Array('保亭', 90, 9);
arrCity[90]=new Array('昌江', 91, 9);
arrCity[91]=new Array('澄迈', 92, 9);
arrCity[92]=new Array('儋州', 93, 9);
arrCity[93]=new Array('定安', 94, 9);
arrCity[94]=new Array('东方', 95, 9);
arrCity[95]=new Array('海口', 96, 9);
arrCity[96]=new Array('乐东', 97, 9);
arrCity[97]=new Array('临高', 98, 9);
arrCity[98]=new Array('陵水', 99, 9);
arrCity[99]=new Array('琼海', 100, 9);
arrCity[100]=new Array('琼中', 101, 9);
arrCity[101]=new Array('三亚', 102, 9);
arrCity[102]=new Array('屯昌', 103, 9);
arrCity[103]=new Array('万宁', 104, 9);
arrCity[104]=new Array('文昌', 105, 9);
arrCity[105]=new Array('五指山', 106, 9);
arrCity[106]=new Array('保定', 107, 10);
arrCity[107]=new Array('沧州', 108, 10);
arrCity[108]=new Array('承德', 109, 10);
arrCity[109]=new Array('邯郸', 110, 10);
arrCity[110]=new Array('衡水', 111, 10);
arrCity[111]=new Array('廊坊', 112, 10);
arrCity[112]=new Array('秦皇岛', 113, 10);
arrCity[113]=new Array('石家庄', 114, 10);
arrCity[114]=new Array('唐山', 115, 10);
arrCity[115]=new Array('邢台', 116, 10);
arrCity[116]=new Array('张家口', 117, 10);
arrCity[117]=new Array('安阳', 118, 11);
arrCity[118]=new Array('鹤壁', 119, 11);
arrCity[119]=new Array('济源', 120, 11);
arrCity[120]=new Array('焦作', 121, 11);
arrCity[121]=new Array('开封', 122, 11);
arrCity[122]=new Array('洛阳', 123, 11);
arrCity[123]=new Array('漯河', 124, 11);
arrCity[124]=new Array('南阳', 125, 11);
arrCity[125]=new Array('平顶山', 126, 11);
arrCity[126]=new Array('濮阳', 127, 11);
arrCity[127]=new Array('三门峡', 128, 11);
arrCity[128]=new Array('商丘', 129, 11);
arrCity[129]=new Array('新乡', 130, 11);
arrCity[130]=new Array('信阳', 131, 11);
arrCity[131]=new Array('许昌', 132, 11);
arrCity[132]=new Array('郑州', 133, 11);
arrCity[133]=new Array('周口', 134, 11);
arrCity[134]=new Array('驻马店', 135, 11);
arrCity[135]=new Array('大庆', 136, 12);
arrCity[136]=new Array('大兴安岭', 137, 12);
arrCity[137]=new Array('哈尔滨', 138, 12);
arrCity[138]=new Array('鹤岗', 139, 12);
arrCity[139]=new Array('黑河', 140, 12);
arrCity[140]=new Array('鸡西', 141, 12);
arrCity[141]=new Array('佳木斯', 142, 12);
arrCity[142]=new Array('牡丹江', 143, 12);
arrCity[143]=new Array('七台河', 144, 12);
arrCity[144]=new Array('齐齐哈尔', 145, 12);
arrCity[145]=new Array('双鸭山', 146, 12);
arrCity[146]=new Array('绥化', 147, 12);
arrCity[147]=new Array('伊春', 148, 12);
arrCity[148]=new Array('鄂州', 149, 13);
arrCity[149]=new Array('恩施', 150, 13);
arrCity[150]=new Array('黄冈', 151, 13);
arrCity[151]=new Array('黄石', 152, 13);
arrCity[152]=new Array('荆门', 153, 13);
arrCity[153]=new Array('荆州', 154, 13);
arrCity[154]=new Array('潜江', 155, 13);
arrCity[155]=new Array('神农架', 156, 13);
arrCity[156]=new Array('十堰', 157, 13);
arrCity[157]=new Array('随州', 158, 13);
arrCity[158]=new Array('天门', 159, 13);
arrCity[159]=new Array('武汉', 160, 13);
arrCity[160]=new Array('仙桃', 161, 13);
arrCity[161]=new Array('咸宁', 162, 13);
arrCity[162]=new Array('襄樊', 163, 13);
arrCity[163]=new Array('孝感', 164, 13);
arrCity[164]=new Array('宜昌', 165, 13);
arrCity[165]=new Array('长沙', 166, 14);
arrCity[166]=new Array('常德', 167, 14);
arrCity[167]=new Array('郴州', 168, 14);
arrCity[168]=new Array('衡阳', 169, 14);
arrCity[169]=new Array('怀化', 170, 14);
arrCity[170]=new Array('娄底', 171, 14);
arrCity[171]=new Array('邵阳', 172, 14);
arrCity[172]=new Array('湘潭', 173, 14);
arrCity[173]=new Array('湘西', 174, 14);
arrCity[174]=new Array('益阳', 175, 14);
arrCity[175]=new Array('永州', 176, 14);
arrCity[176]=new Array('岳阳', 177, 14);
arrCity[177]=new Array('张家界', 178, 14);
arrCity[178]=new Array('株州', 179, 14);
arrCity[179]=new Array('白城', 180, 15);
arrCity[180]=new Array('白山', 181, 15);
arrCity[181]=new Array('长春', 182, 15);
arrCity[182]=new Array('吉林', 183, 15);
arrCity[183]=new Array('辽源', 184, 15);
arrCity[184]=new Array('四平', 185, 15);
arrCity[185]=new Array('松原', 186, 15);
arrCity[186]=new Array('通化', 187, 15);
arrCity[187]=new Array('延边', 188, 15);
arrCity[188]=new Array('常州', 189, 16);
arrCity[189]=new Array('淮安', 190, 16);
arrCity[190]=new Array('连云港', 191, 16);
arrCity[191]=new Array('南京', 192, 16);
arrCity[192]=new Array('南通', 193, 16);
arrCity[193]=new Array('苏州', 194, 16);
arrCity[194]=new Array('宿迁', 195, 16);
arrCity[195]=new Array('泰州', 196, 16);
arrCity[196]=new Array('无锡', 197, 16);
arrCity[197]=new Array('徐州', 198, 16);
arrCity[198]=new Array('盐城', 199, 16);
arrCity[199]=new Array('扬州', 200, 16);
arrCity[200]=new Array('镇江', 201, 16);
arrCity[201]=new Array('抚州', 202, 17);
arrCity[202]=new Array('赣州', 203, 17);
arrCity[203]=new Array('吉安', 204, 17);
arrCity[204]=new Array('景德镇', 205, 17);
arrCity[205]=new Array('九江', 206, 17);
arrCity[206]=new Array('南昌', 207, 17);
arrCity[207]=new Array('萍乡', 208, 17);
arrCity[208]=new Array('上饶', 209, 17);
arrCity[209]=new Array('婺源', 210, 17);
arrCity[210]=new Array('新余', 211, 17);
arrCity[211]=new Array('宜春', 212, 17);
arrCity[212]=new Array('鹰潭', 213, 17);
arrCity[213]=new Array('鞍山', 214, 18);
arrCity[214]=new Array('本溪', 215, 18);
arrCity[215]=new Array('朝阳', 216, 18);
arrCity[216]=new Array('大连', 217, 18);
arrCity[217]=new Array('丹东', 218, 18);
arrCity[218]=new Array('抚顺', 219, 18);
arrCity[219]=new Array('阜新', 220, 18);
arrCity[220]=new Array('葫芦岛', 221, 18);
arrCity[221]=new Array('锦州', 222, 18);
arrCity[222]=new Array('辽阳', 223, 18);
arrCity[223]=new Array('盘锦', 224, 18);
arrCity[224]=new Array('沈阳', 225, 18);
arrCity[225]=new Array('铁岭', 226, 18);
arrCity[226]=new Array('营口', 227, 18);
arrCity[227]=new Array('阿拉善盟', 228, 19);
arrCity[228]=new Array('巴彦淖尔盟', 229, 19);
arrCity[229]=new Array('包头', 230, 19);
arrCity[230]=new Array('赤峰', 231, 19);
arrCity[231]=new Array('鄂尔多斯', 232, 19);
arrCity[232]=new Array('呼和浩特', 233, 19);
arrCity[233]=new Array('呼伦贝尔', 234, 19);
arrCity[234]=new Array('通辽', 235, 19);
arrCity[235]=new Array('乌海', 236, 19);
arrCity[236]=new Array('乌兰察布盟', 237, 19);
arrCity[237]=new Array('锡林郭勒盟', 238, 19);
arrCity[238]=new Array('兴安盟', 239, 19);
arrCity[239]=new Array('固原', 240, 20);
arrCity[240]=new Array('石嘴山', 241, 20);
arrCity[241]=new Array('吴忠', 242, 20);
arrCity[242]=new Array('银川', 243, 20);
arrCity[243]=new Array('格尔木', 244, 21);
arrCity[244]=new Array('果洛', 245, 21);
arrCity[245]=new Array('海北', 246, 21);
arrCity[246]=new Array('海东', 247, 21);
arrCity[247]=new Array('海南', 248, 21);
arrCity[248]=new Array('海西', 249, 21);
arrCity[249]=new Array('黄南', 250, 21);
arrCity[250]=new Array('西宁', 251, 21);
arrCity[251]=new Array('玉树', 252, 21);
arrCity[252]=new Array('滨州', 253, 22);
arrCity[253]=new Array('德州', 254, 22);
arrCity[254]=new Array('东营', 255, 22);
arrCity[255]=new Array('菏泽', 256, 22);
arrCity[256]=new Array('济南', 257, 22);
arrCity[257]=new Array('济宁', 258, 22);
arrCity[258]=new Array('莱芜', 259, 22);
arrCity[259]=new Array('聊城', 260, 22);
arrCity[260]=new Array('临沂', 261, 22);
arrCity[261]=new Array('青岛', 262, 22);
arrCity[262]=new Array('日照', 263, 22);
arrCity[263]=new Array('泰安', 264, 22);
arrCity[264]=new Array('威海', 266, 22);
arrCity[265]=new Array('潍坊', 267, 22);
arrCity[266]=new Array('烟台', 268, 22);
arrCity[267]=new Array('枣庄', 269, 22);
arrCity[268]=new Array('淄博', 270, 22);
arrCity[269]=new Array('长治', 271, 23);
arrCity[270]=new Array('大同', 272, 23);
arrCity[271]=new Array('晋城', 273, 23);
arrCity[272]=new Array('晋中', 274, 23);
arrCity[273]=new Array('临汾', 275, 23);
arrCity[274]=new Array('吕梁', 276, 23);
arrCity[275]=new Array('朔州', 277, 23);
arrCity[276]=new Array('太原', 278, 23);
arrCity[277]=new Array('忻州', 279, 23);
arrCity[278]=new Array('阳泉', 280, 23);
arrCity[279]=new Array('运城', 281, 23);
arrCity[280]=new Array('安康', 282, 24);
arrCity[281]=new Array('宝鸡', 283, 24);
arrCity[282]=new Array('汉中', 284, 24);
arrCity[283]=new Array('商洛', 285, 24);
arrCity[284]=new Array('铜川', 286, 24);
arrCity[285]=new Array('渭南', 287, 24);
arrCity[286]=new Array('西安', 288, 24);
arrCity[287]=new Array('咸阳', 289, 24);
arrCity[288]=new Array('延安', 290, 24);
arrCity[289]=new Array('榆林', 291, 24);
arrCity[290]=new Array('上海', 292, 25);
arrCity[291]=new Array('阿坝', 293, 26);
arrCity[292]=new Array('巴中', 294, 26);
arrCity[293]=new Array('成都', 295, 26);
arrCity[294]=new Array('达州', 296, 26);
arrCity[295]=new Array('德阳', 297, 26);
arrCity[296]=new Array('甘孜', 298, 26);
arrCity[297]=new Array('广安', 299, 26);
arrCity[298]=new Array('广元', 300, 26);
arrCity[299]=new Array('乐山', 301, 26);
arrCity[300]=new Array('凉山', 302, 26);
arrCity[301]=new Array('泸州', 303, 26);
arrCity[302]=new Array('眉山', 304, 26);
arrCity[303]=new Array('绵阳', 305, 26);
arrCity[304]=new Array('内江', 306, 26);
arrCity[305]=new Array('南充', 307, 26);
arrCity[306]=new Array('攀枝花', 308, 26);
arrCity[307]=new Array('遂宁', 309, 26);
arrCity[308]=new Array('雅安', 310, 26);
arrCity[309]=new Array('宜宾', 311, 26);
arrCity[310]=new Array('资阳', 312, 26);
arrCity[311]=new Array('自贡', 313, 26);
arrCity[312]=new Array('高雄', 314, 27);
arrCity[313]=new Array('基隆', 315, 27);
arrCity[314]=new Array('嘉义', 316, 27);
arrCity[315]=new Array('台北', 317, 27);
arrCity[316]=new Array('台南', 318, 27);
arrCity[317]=new Array('台中', 319, 27);
arrCity[318]=new Array('新竹', 320, 27);
arrCity[319]=new Array('天津', 321, 28);
arrCity[320]=new Array('阿里', 322, 29);
arrCity[321]=new Array('昌都', 323, 29);
arrCity[322]=new Array('拉萨', 324, 29);
arrCity[323]=new Array('林芝', 325, 29);
arrCity[324]=new Array('那曲', 326, 29);
arrCity[325]=new Array('日喀则', 327, 29);
arrCity[326]=new Array('山南', 328, 29);
arrCity[327]=new Array('香港', 329, 30);
arrCity[328]=new Array('阿克苏', 330, 31);
arrCity[329]=new Array('阿拉尔', 331, 31);
arrCity[330]=new Array('巴音郭楞', 332, 31);
arrCity[331]=new Array('博尔塔拉', 333, 31);
arrCity[332]=new Array('昌吉', 334, 31);
arrCity[333]=new Array('哈密', 335, 31);
arrCity[334]=new Array('和田', 336, 31);
arrCity[335]=new Array('喀什', 337, 31);
arrCity[336]=new Array('克拉玛依', 338, 31);
arrCity[337]=new Array('克孜勒', 339, 31);
arrCity[338]=new Array('石河子', 340, 31);
arrCity[339]=new Array('图木舒克', 341, 31);
arrCity[340]=new Array('吐鲁番', 342, 31);
arrCity[341]=new Array('乌鲁木齐', 343, 31);
arrCity[342]=new Array('五家渠', 344, 31);
arrCity[343]=new Array('伊犁', 345, 31);
arrCity[344]=new Array('保山', 346, 32);
arrCity[345]=new Array('楚雄', 347, 32);
arrCity[346]=new Array('大理', 348, 32);
arrCity[347]=new Array('德宏', 349, 32);
arrCity[348]=new Array('迪庆', 350, 32);
arrCity[349]=new Array('红河', 351, 32);
arrCity[350]=new Array('昆明', 352, 32);
arrCity[351]=new Array('丽江', 353, 32);
arrCity[352]=new Array('临沧', 354, 32);
arrCity[353]=new Array('怒江', 355, 32);
arrCity[354]=new Array('曲靖', 356, 32);
arrCity[355]=new Array('思茅', 357, 32);
arrCity[356]=new Array('文山', 358, 32);
arrCity[357]=new Array('西双版纳', 359, 32);
arrCity[358]=new Array('玉溪', 360, 32);
arrCity[359]=new Array('昭通', 361, 32);
arrCity[360]=new Array('杭州', 362, 33);
arrCity[361]=new Array('湖州', 363, 33);
arrCity[362]=new Array('嘉兴', 364, 33);
arrCity[363]=new Array('金华', 365, 33);
arrCity[364]=new Array('丽水', 366, 33);
arrCity[365]=new Array('宁波', 367, 33);
arrCity[366]=new Array('衢州', 368, 33);
arrCity[367]=new Array('绍兴', 369, 33);
arrCity[368]=new Array('台州', 370, 33);
arrCity[369]=new Array('温州', 371, 33);
arrCity[370]=new Array('舟山', 372, 33);
arrCity[371]=new Array('重庆', 373, 34);
CityCount=372;
function ChangeList(CityTextId, ProvinceId)
{
    var Obj = document.getElementById(CityTextId);
    Obj.length = 0;
    Obj.options[0] = new Option('请选择', 0);if(ProvinceId==0){Obj.options[0].selected=true;return;}
    var index=1;
    for(var i=0; i<CityCount; i++)
    {
        if(arrCity[i][2]==ProvinceId)
        {
            Obj.options[index]=new Option(arrCity[i][0],arrCity[i][1]);
            index=index+1;
        }
    }
}
function GetCityProvinceID(ProvinceID, CityID) {
    var resultStr;
    for (var i = 0, len = arrProvince.length; i < len; i++) {
        if (ProvinceID == arrProvince[i][1]) {
            resultStr = arrProvince[i][0] + "省";

        }
    }
    for (var j = 0, len = arrCity.length; j < len; j++) {
        if (CityID == arrCity[j][1]) {
            resultStr += arrCity[j][0] + "市";
        }
    }
    return resultStr;
}