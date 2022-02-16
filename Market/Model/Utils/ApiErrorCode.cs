using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Utils
{
    public enum ApiErrorCode
    {
        OK,
        USERNAME_NOT_FOUND,
        WRONG_PASSWORD,
        SERIALIZE_ERROR,
        ID_NOT_FOUND,
        DB_ERROR,
        VALIDATION,
        SECRET_KEY_ERROR,
        JWT_ERROR,
        USERNAME_EXISTS,
        UNAUTHORIZED,
        INVALID_PASSWORD,
        INVALID_USERNAME,
        INVALID_CURRENCY,
        INVALID_COMPRADOR,
        ORDER_NOT_FOUND,
        GET_OR_CREATE_ENTRY_ERROR,
        NO_ITEMS_LEFT,
        SIESA_INTEGRATION_FAILS,
        NOT_FOUND,
        ENTRY_HAS_NO_SERIALS_ERROR,
        ENTRY_IN_SIESA_ERROR,
        SERIAL_EXISTS
    }
}
