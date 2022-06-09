using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Popups;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hotel.UI.Wpf.MVVM.Commands.Popups
{
    public class SaveFilterSettingsCommand : CommandBase
    {
        private readonly AdminReservationsFilterPopupViewModel _parentviewModel;
        private readonly ReservationManager _reservationManager;
        private readonly HotelRoomsManager _hotelRoomManager;
        private readonly UserManager _userManager;
        private readonly ObservableCollection<AdminReservationItemViewModel> _reservationsViewModel;

        public SaveFilterSettingsCommand(AdminReservationsFilterPopupViewModel parentviewModel,
            ReservationManager reservationManager, HotelRoomsManager hotelRoomManager,
            UserManager userManager, ObservableCollection<AdminReservationItemViewModel> reservationsViewModel)
        {
            _parentviewModel = parentviewModel;
            _reservationManager = reservationManager;
            _hotelRoomManager = hotelRoomManager;
            _userManager = userManager;
            _reservationsViewModel = reservationsViewModel;
        }
        public override void Execute(object? parameter)
        {
            var reservationSearchHelper = new ReservationSearchHelper(_hotelRoomManager);
            var reservationFilterdList = new List<IHotelReservation>(_reservationManager.HotelRerservations);
            if (_parentviewModel.IsNameFilterOn)
            {
                reservationFilterdList = reservationSearchHelper.GetReservationsFromName(reservationFilterdList, _parentviewModel.Name);
            }
            if (_parentviewModel.IsPriceFilterON)
            {
                reservationFilterdList = reservationSearchHelper.GetReservationsFromPriceRange(reservationFilterdList, _parentviewModel.MinPrice, _parentviewModel.MaxPrice);
            }
            if (_parentviewModel.IsRoomTypeFilterOn)
            {
                reservationFilterdList = reservationSearchHelper.GetReservationFromRoomType(reservationFilterdList, _parentviewModel.ReservedRoomCategory);
            }
            if (_parentviewModel.IsStatusFilterOn)
            {
                reservationFilterdList = reservationSearchHelper.GetReservationsFromStatus(reservationFilterdList, _parentviewModel.ReservationStatusType.Value);
            }
            if (_parentviewModel.IsDateFilterOn)
            {
                reservationFilterdList = reservationSearchHelper.GetReservationsFromDateRange(reservationFilterdList, _parentviewModel.StartDate, _parentviewModel.EndDate);
            }
            ShowResultsOnReservationViewModel(reservationFilterdList);
        }
        private void ShowResultsOnReservationViewModel(List<IHotelReservation> filteredReservations)
        {
            _reservationsViewModel.Clear();
            foreach (var reservation in filteredReservations)
            {
                _reservationsViewModel.Add(new AdminReservationItemViewModel(reservation, _userManager, _hotelRoomManager));
            }
        }
    }
}
