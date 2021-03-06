﻿using eShop.Cortana;
using eShop.UWP.Activation;
using eShop.UWP.ViewModels.Catalog;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace eShop.UWP.Services
{
    internal class VoiceCommandActivationService : ActivationHandler<VoiceCommandActivatedEventArgs>
    {
        protected override async Task HandleInternalAsync(VoiceCommandActivatedEventArgs args, Type defaultNavItem)
        {
            var voiceCommandService = SimpleIoc.Default.GetInstance<VoiceCommandService>();
            var filterByVoiceCommand = voiceCommandService.RunCommand(args);

            if (IsAuthenticated)
            {
                NavigationService.Navigate(typeof(ItemDetailViewModel).FullName, filterByVoiceCommand);
            }
            else
            {
                NavigationService.Navigate(defaultNavItem.FullName, filterByVoiceCommand);
            }

            await Task.CompletedTask;
        }
    }
}
