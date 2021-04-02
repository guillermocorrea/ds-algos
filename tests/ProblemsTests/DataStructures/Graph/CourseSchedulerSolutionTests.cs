using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Graph;
using Xunit;

namespace ProblemsTests.DataStructures.Graph
{
    public class CourseSchedulerSolutionTests
    {
        [Fact]
        public void CanFinishAllCoursesBruteForce()
        {
            // Given
            int n = 6;
            var prereqs = new int[][] {
             new int[] {1, 0},
             new int[] {2, 1},
             new int[] {2, 5},
             new int[] {0, 3},
             new int[] {4, 3},
             new int[] {3, 5},
             new int[] {4, 5},
            };
            // When
            var actual = CourseSchedulerSolution.CanFinishAllCoursesBruteForce(n, prereqs);
            // Then
            Assert.True(actual);
            Assert.True(CourseSchedulerSolution.CanFinishAllCoursesBruteForce(2, new int[][] {
                new int[] { 1, 0 }
                }));
            Assert.False(CourseSchedulerSolution.CanFinishAllCoursesBruteForce(2, new int[][] {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
                }));
        }

        [Fact]
        public void CanFinishAllCoursesTopologicalSort()
        {
            // Given
            int n = 6;
            var prereqs = new int[][] {
             new int[] {1, 0},
             new int[] {2, 1},
             new int[] {2, 5},
             new int[] {0, 3},
             new int[] {4, 3},
             new int[] {3, 5},
             new int[] {4, 5},
            };
            // When
            var actual = CourseSchedulerSolution.CanFinishAllCoursesBruteForce(n, prereqs);
            // Then
            Assert.True(actual);
            Assert.True(CourseSchedulerSolution.CanFinishAllCoursesTopologicalSort(2, new int[][] {
                new int[] { 1, 0 }
                }));
            Assert.False(CourseSchedulerSolution.CanFinishAllCoursesTopologicalSort(2, new int[][] {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
                }));
        }
    }
}