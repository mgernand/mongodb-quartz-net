﻿using System;
using MongoDB.Bson.Serialization.Attributes;
using Quartz.Spi.MongoDbJobStore.Models.Id;

namespace Quartz.Spi.MongoDbJobStore.Models
{
    internal class FiredTrigger
    {
        public FiredTrigger()
        {
            
        }

        public FiredTrigger(string firedInstanceId, Trigger trigger, JobDetail jobDetail)
        {
            Id = new FiredTriggerId(firedInstanceId, trigger.Id.InstanceName);
            TriggerKey = trigger.Id.GetTriggerKey();
            Fired = DateTime.UtcNow;
            Scheduled = trigger.NextFireTime;
            Priority = trigger.Priority;
            State = trigger.State;

            if (jobDetail != null)
            {
                JobKey = jobDetail.Id.GetJobKey();
                ConcurrentExecutionDisallowed = jobDetail.ConcurrentExecutionDisallowed;
                RequestsRecovery = jobDetail.RequestsRecovery;
            }
        }

        [BsonId]
        public FiredTriggerId Id { get; set; }

        public TriggerKey TriggerKey { get; set; }

        public JobKey JobKey { get; set; }

        public string InstanceId { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Fired { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? Scheduled { get; set; }

        public int Priority { get; set; }

        public TriggerState State { get; set; }

        public bool ConcurrentExecutionDisallowed { get; set; }

        public bool RequestsRecovery { get; set; }
    }
}