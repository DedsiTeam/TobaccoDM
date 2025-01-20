namespace TobaccoDMSystemManagement.Domain.SystemMenus
{
    public class SystemMenu:Entity<Guid>
    {
        public SystemMenu() { }

        public SystemMenu(string _menuName,string _fatherid,int _menuType,string _Identification,int _sort)
        {
            MenuName = _menuName;
            Fatherid= _fatherid;
            MenuType = _menuType;
            Identification = _Identification;
            Sort = _sort;
        }

        /// <summary>
        /// 菜单/按钮 名称
        /// </summary>
        public string MenuName { get; private set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public string Fatherid { get; private set; }

        /// <summary>
        /// 菜单类型  0目录/1菜单/2按钮
        /// </summary>
        public int MenuType { get; private set; }

        /// <summary>
        /// 按钮权限名称
        /// </summary>
        public string Identification { get; private set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int Sort {  get; private set; }
        
        /// <summary>
        ///是否启用 
        /// </summary>
        public bool IsEnable {  get; private set; }

        /// <summary>
        /// 添加时间 
        /// </summary>
        public DateTime CreateTime { get; private set; }


        public void CreateUlidTime(Guid Id)
        {
            this.CreateTime = DateTime.Now;
            this.Id = Id;
        }

        public void EnableTrue()
        {
            this.IsEnable = true;
        }

        public void EnableFalse()
        {
            this.IsEnable = false;
        }

    }
}
