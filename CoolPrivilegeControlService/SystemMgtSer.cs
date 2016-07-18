﻿using CoolPrivilegeControlSerFactory.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using WCF_Infrastructure;
using CoolPrivilegeControlVM.WCFVM;
using CoolPrivilegeControlVM;
using CoolPrivilegeControlDAL.Common;
using CoolPrivilegeControlDAL.Respositories;
using CoolPrivilegeControlVM.EntityVM;
using System.ServiceModel;
using System.ComponentModel.Composition.Hosting;

namespace CoolPrivilegeControlService
{
    public class SystemMgtSer : ServiceBase, ISystemMgtSer
    {
        public SystemMgtSer()
            : base()
        {

        }

        public SystemMgtSer(CompositionContainer Container)
            : base(Container)
        {

        }

        public SystemInfoVM GetSystemInfo(WCFAuthInfoVM entity_WCFAuthInfoVM)
        {
            try
            {
                //Retrieve Language And Session
                //RetrieveLanguageAndSession(entity_WCFAuthInfoVM);

                //

                //List<string> strList_Error = new List<string>();

                //SysInfoSerEditResult returnResult = new SysInfoSerEditResult();

                CoolPrivilegeControlContext dbContext = CoolPrivilegeControlContext.CreateContext();

                SysParmRespository Respo_SysParm = new SysParmRespository();

                //Respo_SysParm.UserId = entity_BaseSession.ID;

                //bool ret = false;

                //ret = CheckAccPrivilege(entity_BaseSession.ID, entity_WCFAuthInfoVM.RequestFunKey, entity_WCFAuthInfoVM.RequestFunTypeKey, ref strList_Error);

                //if (ret)
                //{
                    SystemInfoVM db_SysInfoVM = Respo_SysParm.RetrieveSystemInfo();

                    //returnResult.Entity_SystemInfoVM = db_SysInfoVM;
                //}

                //returnResult.StrList_Error = strList_Error;

                    return db_SysInfoVM;

            }
            catch (Exception ex)
            {
                throw new FaultException<WCFErrorContract>(new WCFErrorContract(ex), ex.Message);
            }
        }

        public WCFReturnResult Update(WCFAuthInfoVM entity_WCFAuthInfoVM, SystemInfoVM entity_SysVM)
        {
            try
            {
                //Retrieve Language And Session
                RetrieveLanguageAndSession(entity_WCFAuthInfoVM);

                

                WCFReturnResult returnResult = new WCFReturnResult();

                CoolPrivilegeControlContext dbContext = CoolPrivilegeControlContext.CreateContext();

                SysParmRespository Respo_SysParm = new SysParmRespository();

                Respo_SysParm.UserId = entity_BaseSession.ID;

                List<string> strList_Error = new List<string>();

                bool ret = false;

                ret = CheckAccPrivilege(entity_BaseSession.ID, entity_WCFAuthInfoVM.RequestFunKey, entity_WCFAuthInfoVM.RequestFunTypeKey, ref strList_Error);

                if (ret)
                {
                    ret = Respo_SysParm.UpdateSystemInfo(entity_SysVM, languageKey, ref strList_Error);
                }

                returnResult.IsSuccess = ret;

                returnResult.StrList_Error = strList_Error;

                return returnResult;

            }
            catch (Exception ex)
            {
                throw new FaultException<WCFErrorContract>(new WCFErrorContract(ex), ex.Message);
            }
        }
    }
}
