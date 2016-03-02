using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanTaiWeb
{
    public class ModelQueryOp
    {
        public ModelQueryOp() { }
        public ModelQueryOp(bool _isMultiple, string _backValueInput, string _backTextInput)
        {
            IsMultiple = _isMultiple;
            BackValueInput = _backValueInput;
            BackTextInput = _backTextInput;
        }
        public ModelQueryOp(bool _isMultiple, string _backValueInput, string _backTextInput, string _currentVal)
        {
            IsMultiple = _isMultiple;
            BackValueInput = _backValueInput;
            BackTextInput = _backTextInput;
            CurrentVal = _currentVal;
        }
        /// <summary>
        /// 部分视图名称
        /// </summary>
        public string PartialName { get; set; }
        /// <summary>
        /// 是否多选
        /// </summary>
        public bool IsMultiple { get; set; }

        /// <summary>
        /// 返回值赋值的文本id
        /// </summary>
        public string BackValueInput { get; set; }

        /// <summary>
        /// 返回文本赋值的文本id
        /// </summary>
        public string BackTextInput { get; set; }

        /// <summary>
        /// 当前绑定值
        /// </summary>
        public string CurrentVal { get; set; }
    }
}