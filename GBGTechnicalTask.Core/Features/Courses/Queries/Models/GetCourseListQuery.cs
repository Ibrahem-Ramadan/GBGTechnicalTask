using GBGTechnicalTask.Core.Bases.Response;
using GBGTechnicalTask.Core.Features.Courses.Queries.Responses;
using GBGTechnicalTask.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Core.Features.Courses.Queries.Models
{
    public class GetCourseListQuery:IRequest<Response<IList<GetCourseResponse>>>
    {
    }
}
