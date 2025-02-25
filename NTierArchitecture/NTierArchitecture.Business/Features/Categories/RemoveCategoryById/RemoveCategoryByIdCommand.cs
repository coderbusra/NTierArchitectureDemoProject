using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategoryById
{
    public sealed record RemoveCategoryByIdCommand (Guid Id): IRequest;
}
