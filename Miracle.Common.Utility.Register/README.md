# RegisterHelper
一个注册表常用操作类库,源码基础来源于互联网.

该类库中使用RegisterHelper进行注册表的操作.
该类需实例化使用.其中包含如下函数:
<pre><code>

属性: 
		默认注册表基项: BaseKey

构造函数:
		RegisterHelper();

        RegisterHelper(string baseKey);
			param name= "baseKey":基项名称

公共方法:
          写入注册表,如果指定项已经存在,则修改指定项的值
          void SetValue(KeyType keytype, string key, string name, string values);
				param name="keytype":注册表基项枚举
				param name="key":注册表项,不包括基项
				param name="name":值名称
				param name="values":值

          读取注册表
          string GetValue(KeyType keytype, string key, string name);
				param name="keytype":注册表基项枚举
				param name="key":注册表项,不包括基项
				param name="name":值名称
				returns:返回字符串

          删除注册表中的值
          void DeleteValue(KeyType keytype, string key, string name);
		        param name="keytype":注册表基项枚举
                param name="key":注册表项名称,不包括基项
				param name="name":值名称

          删除注册表中的指定项
          void DeleteSubKey(KeyType keytype, string key);
			   param name="keytype":注册表基项枚举
			   param name="key":注册表中的项,不包括基项
			   returns:返回布尔值,指定操作是否成功

          判断指定项是否存在
          bool IsExist(KeyType keytype, string key);
			   param name="keytype":基项枚举
			   param name="key":指定项字符串
			   returns:返回布尔值,说明指定项是否存在

          检索指定项关联的所有值
          string[] GetValues(KeyType keytype, string key);
			   param name="keytype":基项枚举
			   param name="key":指定项字符串
			   returns:返回指定项关联的所有值的字符串数组

          将对象所有属性写入指定注册表中
          void SetObjectValue(KeyType keyType, string key, Object obj);
			   param name="keytype":注册表基项枚举
			   param name="key":注册表项,不包括基项
			   param name="obj":传入的对象

</code></pre>