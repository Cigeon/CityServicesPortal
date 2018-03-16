using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Core.Commands;
using CityServicesPortal.Petitions.Domain.Core.Notifications;
using CityServicesPortal.Petitions.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            //foreach (var error in message.ValidationResult.Errors)
            //{
            //    _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            //}
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
