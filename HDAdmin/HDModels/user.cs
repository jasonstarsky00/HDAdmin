using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class user
    {

        private int _id;
        private string _userName;
        private string _passWord;
        private string _name;
        private string _onlyCode;
        private int _balance; 
        private int _integral;
        private string _recomCode;
        private string _userAvatarSrc;
        private int _parentId;
        private string _parentUserName;
        private string _parentName;
        private int _topUid;
        private string _topUserName;
        private string _topName;
        private int _isVip;
        private int _isManager;
        private int _haveDownloads;
        private int _downloaded;
        private string _regIp;
        private DateTime _regTime;
        private int _loginCount;
        private string _lastLoginIp;
        private DateTime _lastLoginTime;
        private int _isFreeze;

        /// <summary>
        /// 用户id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string  PassWord
        {
            get { return _passWord; }
            set { _passWord = value; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string OnlyCode
        {
            get { return _onlyCode; }
            set { _onlyCode = value; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral
        {
            get { return _integral; }
            set { _integral = value; }
        }
        /// <summary>
        /// 推荐编码
        /// </summary>
        public string RecomCode
        {
            get { return _recomCode; }
            set { _recomCode = value; }
        }
        /// <summary>
        /// 用户头像路径
        /// </summary>
        public string UserAvatarSrc
        {
            get { return _userAvatarSrc; }
            set { _userAvatarSrc = value; }
        }
        /// <summary>
        /// 父级id
        /// </summary>
        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        /// <summary>
        /// 父级账号
        /// </summary>
        public string ParentUserName
        {
            get { return _parentUserName; }
            set { _parentUserName = value; }
        }
        /// <summary>
        /// 父级名称
        /// </summary>
        public string ParentName
        {
            get { return _parentName; }
            set { _parentName = value; }
        }
        /// <summary>
        /// 最上级id
        /// </summary>
        public int TopUid
        {
            get { return _topUid; }
            set { _topUid = value; }
        }
        /// <summary>
        /// vip
        /// </summary>
        public int IsVip
        {
            get { return _isVip; }
            set { _isVip = value; }
        }
        /// <summary>
        /// 最上级id
        /// </summary>
        public string TopUserName
        {
            get { return _topUserName; }
            set { _topUserName = value; }
        }
        /// <summary>
        /// 最上级名称
        /// </summary>
        public string TopName
        {
            get { return _topName; }
            set { _topName = value; }
        }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public int IsManager
        {
            get { return _isManager; }
            set { _isManager = value; }
        }
        /// <summary>
        /// 拥有的下载次数
        /// </summary>
        public int HaveDownloads
        {
            get { return _haveDownloads; }
            set { _haveDownloads = value; }
        }
        /// <summary>
        /// 已使用的下载次数
        /// </summary>
        public int Downloaded
        {
            get { return _downloaded; }
            set { _downloaded = value; }
        }
        /// <summary>
        /// 注册的ip
        /// </summary>
        public string RegIp
        {
            get { return _regIp; }
            set { _regIp = value; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime
        {
            get { return _regTime; }
            set { _regTime = value; }
        }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCount
        {
            get { return _loginCount; }
            set { _loginCount = value; }
        }
        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIp
        {
            get { return _lastLoginIp; }
            set { _lastLoginIp = value; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastLoginTime; }
            set { _lastLoginTime = value; }
        }
        /// <summary>
        /// 是否冻结
        /// </summary>
        public int IsFreeze
        {
            get { return _isFreeze; }
            set { _isFreeze = value; }
        }
    }
}
