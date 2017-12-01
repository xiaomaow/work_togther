using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Data;

namespace work_togther.Common
{
    /// <summary>
    /// XML帮助类
    /// </summary>
    public class XMLHelper
    {
        #region 字段定义
        /// <summary>
        /// XML文件的物理路径
        /// </summary>
        private string _filePath = string.Empty;

        /// <summary>
        /// XML文档
        /// </summary>
        private XmlDocument _xml;
        /// <summary>
        /// XML的根节点
        /// </summary>
        private XmlElement _element;
        /// <summary>
        /// 系统方法帮助类
        /// </summary>
        SysHelper _sys_helper = new SysHelper();
        #endregion

        #region 构造方法
        /// <summary>
        /// 实例化XMLHelper对象
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public XMLHelper(string xmlFilePath)
        {
            _filePath = _sys_helper.GetPath(xmlFilePath);
        }
        #endregion

        #region 创建XML的根节点
        private void CreateXMLElement()
        { 
            //创建一个XML对象
            _xml = new XmlDocument();
            if (File.Exists(_filePath))
            {
                //加载XML文件
                _xml.Load(this._filePath);
            }
            //为XML的根节点赋值
            _element = _xml.DocumentElement;

        }
        #endregion

        #region 获取指定XPath表达式的节点对象
        /// <summary>
        /// 获取指定XMLPath表达式的节点对象
        /// </summary>
        /// <param name="xPath">XMLPath表达式
        /// 返利1：@"Skill/First/SkillItem",等效于@"//Skill/First/SkillItem"
        /// 范例2：@"Table[USERNAME='a']",[]表示筛选，USERNAME是table下的一个子节点
        /// 返利3：@"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性
        /// </param>
        /// <returns></returns>
        public XmlNode GetNode(string xPath)
        {
            //创建XML的根节点
            CreateXMLElement();
            //返回XPath节点的值
            return _element.SelectSingleNode(xPath);
        }
        #endregion

        #region 获取执行XPath表达式节点的值
        /// <summary>
        /// 获取指定XPath表达式节点的值
        /// </summary>
        /// <param name="path">
        /// 范例1：@"Skill/First/SkillItem",等效于@"//skill/First/SkillItem"
        /// 范例2：@"Table[USERNAME='a']",[]表示筛选。USERNAME是Table下的一个子节点
        /// 范例3：@"ApplyPost/Item[@item='岗位编号']",@itemName是Item节点的属性
        /// </param>
        /// <returns></returns>
        public string GetValue(string path)
        {
            //创建XML的根节点
            CreateXMLElement();
            //返回XPath节点的值
            return _element.SelectSingleNode(path).InnerText;
        }
        #endregion

        #region 获取指定XPath表达式节点的属性值
        /// <summary>
        /// 获取指定XPath表达式节点的属性值
        /// </summary>
        /// <param name="xPath">XPATH表达式
        /// 范例1：@"Skill/First/SkillItem",等效于@"//skill/First/SkillItem"
        /// 范例2：@"Table[USERNAME='a']",[]表示筛选。USERNAME是Table下的一个子节点
        /// 范例3：@"ApplyPost/Item[@item='岗位编号']",@itemName是Item节点的属性
        /// </param>
        /// <param name="attributeName">属性名</param>
        /// <returns></returns>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            //创建XML的根节点
            CreateXMLElement();
            //返回XPATH节点的属性值
            return _element.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion

        #region 新增节点
        /// <summary>
        /// 1.功能：新增节点
        /// 2.使用条件：将任意节点插入到当前XML文件中
        /// </summary>
        /// <param name="xmlNode"></param>
        public void AppendNode(XmlNode xmlNode)
        {
            //创建XML的根节点
            CreateXMLElement();
            //导入节点
            XmlNode node = _xml.ImportNode(xmlNode, true);
            //将节点插入到根节点下
            _element.AppendChild(node);
        }

        /// <summary>
        /// 1.功能：新增节点
        /// 2.使用条件：将DataSet中的第一条记录插入Xml文件中
        /// </summary>
        /// <param name="ds"></param>
        public void AppendNode(DataSet ds)
        {
            //创建XmlDataDocument对象
            XmlDataDocument xmlDataDocument = new XmlDataDocument(ds);
            //导入节点
            XmlNode node = xmlDataDocument.DocumentElement.FirstChild;
            //将节点插入到根节点下
            AppendNode(node);
        }
        #endregion

        #region 删除节点
        /// <summary>
        /// 删除指定XPath表达式的节点
        /// </summary>
        /// <param name="node">
        /// 范例1：@"Skill/First/SkillItem",等效于@"//skill/First/SkillItem"
        /// 范例2：@"Table[USERNAME='a']",[]表示筛选。USERNAME是Table下的一个子节点
        /// 范例3：@"ApplyPost/Item[@item='岗位编号']",@itemName是Item节点的属性
        /// </param>
        public void RemoveNode(string xpath)
        {
            //创建XML的根节点
            CreateXMLElement();
            //获取要删除的节点
            XmlNode node = _xml.SelectSingleNode(xpath);
            //删除节点
            _element.RemoveChild(node);
        }
        #endregion

        #region 保存XML文件
        /// <summary>
        /// 保存XML文件
        /// </summary>
        public void Save()
        {
            //创建XML的根节点
            CreateXMLElement();
            //保存XML文件
            _xml.Save(this._filePath);
        }
        #endregion
    }
}
