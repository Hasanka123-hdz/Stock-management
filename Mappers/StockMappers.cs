using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {

        // that converts a Stock object to a StockDto object. 
        public static StockDto ToStockDto(this Stock stockModel){
            return new StockDto{
              Id = stockModel.Id,
              Symbol = stockModel.Symbol,  
              CompanyName = stockModel.CompanyName,
              Purchase = stockModel.Purchase,
              LastDiv = stockModel.LastDiv,
              Industry = stockModel.Industry,
              MarketCap = stockModel.MarketCap,
              Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        // The purpose is to create a Stock object from a CreateStockRequestDto object by mapping relevant properties.
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto){
            return new Stock{
              Symbol = stockDto.Symbol,
              CompanyName = stockDto.CompanyName,
              Purchase = stockDto.Purchase,
              LastDiv = stockDto.LastDiv,
              Industry = stockDto.Industry,
              MarketCap = stockDto.MarketCap
            };
        }

    }
}