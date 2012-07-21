﻿using System;
using System.Collections.Generic;
using System.Linq;
using MediaBrowser.Model.Entities;

namespace MediaBrowser.Api.HttpHandlers
{
    public abstract class ItemListHandler : JsonHandler
    {
        protected sealed override object ObjectToSerialize
        {
            get
            {
                return ItemsToSerialize.Select(i =>
                {
                    return ApiService.GetSerializationObject(i, false, UserId);

                });
            }
        }

        protected abstract IEnumerable<BaseItem> ItemsToSerialize
        {
            get;
        }

        protected Guid UserId
        {
            get
            {
                return Guid.Parse(QueryString["userid"]);
            }
        }
    }
}
