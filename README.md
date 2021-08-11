# AttendanceManagement
NET5 WPF WEB API

开发环境
Windows10 64

WebApi 
  Swagger、
  
  Autofac、
  
  Redis(建议使用64位，时间充沛的情况可以自行研究32位)
  
    //获取 Reids 缓存值
    string GetValue(string key);
    
    //查询所有的key
    List<TEntity> GetList<TEntity>(string key);
    
    //获取值，并序列化
    TEntity Get<TEntity>(string key);
    
    //保存
    void Set(string key, object value, TimeSpan cacheTime);
    
    //判断是否存在
    bool Get(string key);
    
    //移除某一个缓存值
    void Remove(string key);
    
    //全部清除
    void Clear();
  、
  仓储模式、
  
  JWT权限、
  
  轻型ORM框架 Sqlsugar+异步泛型仓储
  
  包含库
    Attendance 接口
    
    Attendance.core.Common 工具、
    
    Attendance.IRepository 仓库接口、
    
    Attendance.IService  BLL、
    
    Attendance.Model 实体、
    
    Attendance.Repository 仓库、
    
    Attendance.Service   BLL、
  
WPF 
  MEF开发模式、
  
  控件自定义 
  (也可以使用第三方框架)
  
  
  库
  AttendanceClient 客户端
  
  Attendance.ExportOrImport(插件 命名规范 Attendance.*.dll)
