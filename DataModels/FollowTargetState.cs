using System.Collections.Generic;

namespace FirstPersonCameraContinued.DataModels
{
    public class FollowTargetState<TEntity>
    {
        private readonly TEntity _nullEntity;
        private readonly IEqualityComparer<TEntity> _comparer;

        public FollowTargetState(TEntity nullEntity)
            : this(nullEntity, EqualityComparer<TEntity>.Default)
        {
        }

        public FollowTargetState(TEntity nullEntity, IEqualityComparer<TEntity> comparer)
        {
            _nullEntity = nullEntity;
            _comparer = comparer;
            SelectedSubject = nullEntity;
            AttachmentTarget = nullEntity;
        }

        public TEntity SelectedSubject { get; private set; }

        public TEntity AttachmentTarget { get; private set; }

        public int AttachmentRevision { get; private set; }

        public bool HasSubject => !_comparer.Equals(SelectedSubject, _nullEntity);

        public void SelectSubject(TEntity subject)
        {
            SelectedSubject = subject;
            SetAttachmentTarget(subject);
        }

        public void ResolveAttachmentTarget(TEntity target)
        {
            SetAttachmentTarget(HasSubject ? target : _nullEntity);
        }

        private void SetAttachmentTarget(TEntity target)
        {
            if (_comparer.Equals(AttachmentTarget, target))
                return;

            AttachmentTarget = target;
            AttachmentRevision++;
        }
    }
}
