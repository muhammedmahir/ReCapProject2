﻿using Core.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            var result = CheckReturnDate(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(result.Message);

        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetRentalDetails(x => x.CarId == carId && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(x => x.CarId == carId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(int Id)
        {
            var result = _rentalDal.GetAll(x => x.CarId == Id);
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalUpdatedReturnDateError);
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult(Messages.RentalUpdatedReturnDate);
        }
        public IDataResult<List<Rental>> GetUnAvailableCars()
        {
            if (_rentalDal.GetAll(r => r.RentDate != null).Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.FailUnAvailableCars);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate != null), Messages.ListedOfUnAvailableCars);
        }
        public IDataResult<List<Rental>> GetAvailableCars()
        {
            if (_rentalDal.GetAll(r => r.RentDate == null).Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate == null), Messages.OutOfStock);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate == null));


        }
    }
}