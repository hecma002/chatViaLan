﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="LANCHAT")]
	public partial class UserDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUSER(USER instance);
    partial void UpdateUSER(USER instance);
    partial void DeleteUSER(USER instance);
    partial void InsertmMESSAGE(mMESSAGE instance);
    partial void UpdatemMESSAGE(mMESSAGE instance);
    partial void DeletemMESSAGE(mMESSAGE instance);
    #endregion
		
		public UserDBDataContext() : 
				base(global::Client.Properties.Settings.Default.LANCHATConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public UserDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<USER> USERs
		{
			get
			{
				return this.GetTable<USER>();
			}
		}
		
		public System.Data.Linq.Table<mMESSAGE> mMESSAGEs
		{
			get
			{
				return this.GetTable<mMESSAGE>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.USERS")]
	public partial class USER : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ID;
		
		private string _UserName;
		
		private string _HashPassword;
		
		private EntitySet<mMESSAGE> _mMESSAGEs;
		
		private EntitySet<mMESSAGE> _mMESSAGEs1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(string value);
    partial void OnIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnHashPasswordChanging(string value);
    partial void OnHashPasswordChanged();
    #endregion
		
		public USER()
		{
			this._mMESSAGEs = new EntitySet<mMESSAGE>(new Action<mMESSAGE>(this.attach_mMESSAGEs), new Action<mMESSAGE>(this.detach_mMESSAGEs));
			this._mMESSAGEs1 = new EntitySet<mMESSAGE>(new Action<mMESSAGE>(this.attach_mMESSAGEs1), new Action<mMESSAGE>(this.detach_mMESSAGEs1));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Char(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HashPassword", DbType="VarChar(50)")]
		public string HashPassword
		{
			get
			{
				return this._HashPassword;
			}
			set
			{
				if ((this._HashPassword != value))
				{
					this.OnHashPasswordChanging(value);
					this.SendPropertyChanging();
					this._HashPassword = value;
					this.SendPropertyChanged("HashPassword");
					this.OnHashPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="USER_mMESSAGE", Storage="_mMESSAGEs", ThisKey="ID", OtherKey="IDSender")]
		public EntitySet<mMESSAGE> mMESSAGEs
		{
			get
			{
				return this._mMESSAGEs;
			}
			set
			{
				this._mMESSAGEs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="USER_mMESSAGE1", Storage="_mMESSAGEs1", ThisKey="ID", OtherKey="IDReciever")]
		public EntitySet<mMESSAGE> mMESSAGEs1
		{
			get
			{
				return this._mMESSAGEs1;
			}
			set
			{
				this._mMESSAGEs1.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_mMESSAGEs(mMESSAGE entity)
		{
			this.SendPropertyChanging();
			entity.USER = this;
		}
		
		private void detach_mMESSAGEs(mMESSAGE entity)
		{
			this.SendPropertyChanging();
			entity.USER = null;
		}
		
		private void attach_mMESSAGEs1(mMESSAGE entity)
		{
			this.SendPropertyChanging();
			entity.USER1 = this;
		}
		
		private void detach_mMESSAGEs1(mMESSAGE entity)
		{
			this.SendPropertyChanging();
			entity.USER1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.mMESSAGE")]
	public partial class mMESSAGE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _IDSender;
		
		private string _IDReciever;
		
		private string _Content;
		
		private EntityRef<USER> _USER;
		
		private EntityRef<USER> _USER1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDSenderChanging(string value);
    partial void OnIDSenderChanged();
    partial void OnIDRecieverChanging(string value);
    partial void OnIDRecieverChanged();
    partial void OnContentChanging(string value);
    partial void OnContentChanged();
    #endregion
		
		public mMESSAGE()
		{
			this._USER = default(EntityRef<USER>);
			this._USER1 = default(EntityRef<USER>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDSender", DbType="Char(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IDSender
		{
			get
			{
				return this._IDSender;
			}
			set
			{
				if ((this._IDSender != value))
				{
					if (this._USER.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDSenderChanging(value);
					this.SendPropertyChanging();
					this._IDSender = value;
					this.SendPropertyChanged("IDSender");
					this.OnIDSenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDReciever", DbType="Char(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IDReciever
		{
			get
			{
				return this._IDReciever;
			}
			set
			{
				if ((this._IDReciever != value))
				{
					if (this._USER1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDRecieverChanging(value);
					this.SendPropertyChanging();
					this._IDReciever = value;
					this.SendPropertyChanged("IDReciever");
					this.OnIDRecieverChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Content", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				if ((this._Content != value))
				{
					this.OnContentChanging(value);
					this.SendPropertyChanging();
					this._Content = value;
					this.SendPropertyChanged("Content");
					this.OnContentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="USER_mMESSAGE", Storage="_USER", ThisKey="IDSender", OtherKey="ID", IsForeignKey=true)]
		public USER USER
		{
			get
			{
				return this._USER.Entity;
			}
			set
			{
				USER previousValue = this._USER.Entity;
				if (((previousValue != value) 
							|| (this._USER.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._USER.Entity = null;
						previousValue.mMESSAGEs.Remove(this);
					}
					this._USER.Entity = value;
					if ((value != null))
					{
						value.mMESSAGEs.Add(this);
						this._IDSender = value.ID;
					}
					else
					{
						this._IDSender = default(string);
					}
					this.SendPropertyChanged("USER");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="USER_mMESSAGE1", Storage="_USER1", ThisKey="IDReciever", OtherKey="ID", IsForeignKey=true)]
		public USER USER1
		{
			get
			{
				return this._USER1.Entity;
			}
			set
			{
				USER previousValue = this._USER1.Entity;
				if (((previousValue != value) 
							|| (this._USER1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._USER1.Entity = null;
						previousValue.mMESSAGEs1.Remove(this);
					}
					this._USER1.Entity = value;
					if ((value != null))
					{
						value.mMESSAGEs1.Add(this);
						this._IDReciever = value.ID;
					}
					else
					{
						this._IDReciever = default(string);
					}
					this.SendPropertyChanged("USER1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
